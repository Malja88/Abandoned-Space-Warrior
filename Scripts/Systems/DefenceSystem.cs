using Unity.Entities;
using Unity.Jobs;
using Unity.Physics.Stateful;
using Unity.Physics.Systems;

//We did not need the ReferenceEntity so we deleted the IConvertGameObjectToEntity interface
//and the TriggerVolumeChangeMaterial component

[UpdateInGroup(typeof(FixedStepSimulationSystemGroup))]
[UpdateAfter(typeof(ExportPhysicsWorld))]
public partial class DefenceSystem : SystemBase
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
        var nonTriggerMask = m_NonTriggerMask;

        Entities
            .WithoutBurst()
            .ForEach((Entity entity, DefenceTag tag, ref DynamicBuffer<StatefulTriggerEvent> triggerEventBuffer) =>
            {
                for (int i = 0; i < triggerEventBuffer.Length; i++)
                {
                    var triggerEvent = triggerEventBuffer[i];
                    var otherEntity = triggerEvent.GetOtherEntity(entity);

                    if (triggerEvent.State == StatefulEventState.Stay || !nonTriggerMask.Matches(otherEntity))
                    {
                        continue;
                    }

                    if (triggerEvent.State == StatefulEventState.Enter && tag.DefenceAction is IBonusAbility ability)
                    {
                        ability.Collect();
                        commandBuffer.DestroyEntity(entity);
                    }
                    //The following is what happens on exitTrigger
                    else
                    {

                    }

                }

            }).Run();

        m_CommandBufferSystem.AddJobHandleForProducer(Dependency);
    }

}
