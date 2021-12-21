using Unity.Entities;
using Unity.Scenes;
using UnityEngine;


public class SubScenesLoadingSystem : SystemBase
{

    private SceneSystem scene_system;
    
    
    protected override void OnCreate()
    {
        scene_system = World.GetOrCreateSystem<SceneSystem>();
    }

    protected override void OnUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadSubScene(SubScenesHolder.instance.subScene);
        }
    }

    private void LoadSubScene(SubScene sub_scenes)
    {
        scene_system.LoadSceneAsync(sub_scenes.SceneGUID);
    }

}
