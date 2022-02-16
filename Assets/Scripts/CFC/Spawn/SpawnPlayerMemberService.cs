using System.Threading.Tasks;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class SpawnPlayerMemberService
{

    private GameObject                   spawn_prefab;
    private GameObjectConversionSettings converstion_settings;

    private EntityManager entity_manager;
    private Entity        spawn_entity;

    public SpawnPlayerMemberService()  =>  loadSettings();
    

    private async void loadSettings() { 
    
  

        var load_request =  Resources.LoadAsync<GameObject>("Chicken_member");
       
        while (!load_request.isDone) {
            await Task.Yield();
        }
        spawn_prefab         = (GameObject) load_request.asset;

        entity_manager       = World.DefaultGameObjectInjectionWorld.EntityManager;
        converstion_settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, new BlobAssetStore());
        spawn_entity         = GameObjectConversionUtility.ConvertGameObjectHierarchy(spawn_prefab, converstion_settings);

    }

    public void generatePlayerMember() {
       
        var entity = entity_manager.Instantiate(spawn_entity);

        entity_manager.SetComponentData(entity, new Translation
        {
            Value = new float3(UnityEngine.Random.Range(-50, 50), 0f, UnityEngine.Random.Range(-50, 50))
        }) ;
   
    }
}
