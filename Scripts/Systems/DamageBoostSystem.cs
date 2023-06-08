using System.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Physics.Stateful;
using Unity.Physics.Systems;
using UnityEngine;
using static SpeedBoostTag;

//We did not need the ReferenceEntity so we deleted the IConvertGameObjectToEntity interface
//and the TriggerVolumeChangeMaterial component

[UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
[UpdateAfter(typeof(ExportPhysicsWorld))]
public partial class DamageBoostSystem : SystemBase
{
    private EndFixedStepSimulationEntityCommandBufferSystem m_CommandBufferSystem;

    private EntityQueryMask m_NonTriggerMask;

    protected override void OnCreate()
    {
        m_CommandBufferSystem = World.GetOrCreateSystem<EndFixedStepSimulationEntityCommandBufferSystem>();
        m_NonTriggerMask = EntityManager.GetEntityQueryMask(
            GetEntityQuery(new EntityQueryDesc
            {
                None = new ComponentType[]
                {
                    typeof(StatefulTriggerEvent)
                }
            })
        );
    }

    protected override void OnUpdate()
    {
        var commandBuffer = m_CommandBufferSystem.CreateCommandBuffer();
        // Need this extra variable here so that it can
        // be captured by Entities.ForEach loop below
        var nonTriggerMask = m_NonTriggerMask;

        Entities
            .WithoutBurst()
            .ForEach((Entity entity, DamageBoostTag tag, ref DynamicBuffer<StatefulTriggerEvent> triggerEventBuffer) =>
            {
                for (int i = 0; i < triggerEventBuffer.Length; i++)
                {
                    var triggerEvent = triggerEventBuffer[i];
                    var otherEntity = triggerEvent.GetOtherEntity(entity);

                    // exclude other triggers and processed events
                    if (triggerEvent.State == StatefulEventState.Stay || !nonTriggerMask.Matches(otherEntity))
                    {
                        continue;
                    }

                    if (triggerEvent.State == StatefulEventState.Enter && tag.DamageBoostAction is IBonusAbility ability)
                    {
                        ability.Collect();
                        commandBuffer.DestroyEntity(entity);
                    }
                    //The following is what happens on exit
                    else
                    {

                    }

                }

            }).Run();

        m_CommandBufferSystem.AddJobHandleForProducer(Dependency);
    }

}