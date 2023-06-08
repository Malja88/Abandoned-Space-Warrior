using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class UserInputData : MonoBehaviour, IConvertGameObjectToEntity
{
    [Header("Actions")]
    public MonoBehaviour ShootAction;
    public MonoBehaviour ReloadAction;
    [Header("Animations")]
    public string moveAnimHash;
    public string shootInputHash;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        if(PhotonView.Get(gameObject).IsMine)
        {
            dstManager.AddComponentData(entity, new InputData());
            if (ShootAction != null && ShootAction is IAbility)
            {
                dstManager.AddComponentData(entity, new ShootData());
            }
            if (moveAnimHash != string.Empty)
            {
                dstManager.AddComponentData(entity, new AnimationData());
            }
            dstManager.AddComponentData(entity, new RotationData());
            if (ReloadAction != null && ReloadAction is IAbility)
            {
                dstManager.AddComponentData(entity, new ReloadData());
            }
        }
    }

    public struct InputData: IComponentData
    {
        public float2 Move;
        public float Shoot;
        public float Reload;
    }
    public struct ShootData: IComponentData
    {
        
    }

    public struct AnimationData: IComponentData
    {

    }

    public struct RotationData : IComponentData
    {
        
    }

    public struct ReloadData: IComponentData
    {

    }

    public struct HasTarget: IComponentData
    {
        public Entity TargetEntity;
    }
}
