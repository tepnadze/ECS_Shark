using Unity.Entities;
using Unity.VisualScripting;
using UnityEngine;


[RequiresEntityConversion, AddComponentMenu("Custom Autoring/Camera Autoring")]
public class CameraAutoring : MonoBehaviour , IConvertGameObjectToEntity
{
    [SerializeField] private CameraFollower camera_follower_prefab;
    
    
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var camera_follower = camera_follower_prefab.GetComponent<CameraFollower>();
        if (camera_follower == null)
        {
            camera_follower = camera_follower_prefab.AddComponent<CameraFollower>();
        }

        camera_follower.entity_to_follow = entity;

    }
}
