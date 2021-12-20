using System;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

   [SerializeField] private Vector3 follow_offset;
   
   
   public Entity entity_to_follow;


   private EntityManager entity_manager;
   
   

   private void Awake()
   {
      entity_manager = World.DefaultGameObjectInjectionWorld.EntityManager;
   }

   private void LateUpdate()
   {
      followTarget();
   }

   private void followTarget()
   {
      if (entity_to_follow == null) return;

      var translation = entity_manager.GetComponentData<Translation>(entity_to_follow);

      transform.position = new Vector3(translation.Value.x,translation.Value.y,translation.Value.z) + follow_offset;
   }
}
