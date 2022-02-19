using System;
using System.Threading.Tasks;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class SpawnPlayerMemberService : IDisposable
{

    private GameObject                   spawn_prefab          = null;
    private GameObjectConversionSettings converstion_settings  = null;
    private BlobAssetStore               blob_asset            = null;


    private EntityManager entity_manager;
    private Entity        spawn_entity;

    private float         radius = 3f;

    public SpawnPlayerMemberService()  =>  loadSettings();

    public void Dispose()
    {
        blob_asset.Dispose();
    }
        
    private async void loadSettings() { 
    
  
        var load_request =  Resources.LoadAsync<GameObject>("Chicken_member");
       
        while (!load_request.isDone) {
            await Task.Yield();
        }
        spawn_prefab         = (GameObject) load_request.asset;

        blob_asset           = new BlobAssetStore();
        entity_manager       = World.DefaultGameObjectInjectionWorld.EntityManager;
        converstion_settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, blob_asset);
        spawn_entity         = GameObjectConversionUtility.ConvertGameObjectHierarchy(spawn_prefab, converstion_settings);

    }

    public void generatePlayerMember() {
       
        var entity = entity_manager.Instantiate(spawn_entity);

        entity_manager.SetComponentData(entity, new Translation
        {
            Value = getRandomCirclePos()
        });

        radius += 0.25f;
    }

    private float3 getRandomCirclePos() {
       
        var a = UnityEngine.Random.Range(0f, 1f);
        var b = UnityEngine.Random.Range(0f, 1f);

        if (b < a)
        {
            var temp = b;
            b = a;
            a = temp;
        }


        var pos = new float3(
            b * radius * Mathf.Cos(2 * Mathf.PI * a / b),
            0f,
            b * radius * Mathf.Sin(2 * Mathf.PI * a / b));

        return pos;

    }

  
}
