using Unity.Entities;
using Unity.Scenes;


public class SubScenesLoadingSystem : SystemBase
{
    
    private SceneSystem scene_system;
    
    protected override void OnCreate() => scene_system = World.GetOrCreateSystem<SceneSystem>();

    protected override void OnUpdate()
    {
        /// Check Events 
    }

    private void LoadSubScene(SubScene sub_scenes) => scene_system.LoadSceneAsync(sub_scenes.SceneGUID);
    private void UnloadSubScene(SubScene sub_scene) => scene_system.UnloadScene(sub_scene.SceneGUID);
}
