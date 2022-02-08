using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;

public class TestingSystem : SystemBase
{

    private EntityQuery entity_query;
    private NativeArray<Entity> entity_array;
    
    protected override void OnUpdate()
    {
        entity_query = GetEntityQuery(ComponentType.ReadOnly<TestingEntityComponent>());
        entity_array = entity_query.ToEntityArray(Allocator.Temp);
        
        var translation =  GetComponent<Translation>(entity_array[0]);
        
        Entities.ForEach((ref Translation translation_player, ref TestingPlayerComponent player_component) =>
        {

           var direction = translation.Value - translation_player.Value;
           translation_player.Value += direction / 10f;

        }).Schedule();
    }

    protected override void OnStopRunning()
    {
        base.OnStopRunning();
       
        entity_query.Dispose();
        entity_array.Dispose();
    }
    
}
