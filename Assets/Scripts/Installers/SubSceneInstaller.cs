using UnityEngine;
using Zenject;

public class SubSceneInstaller : MonoInstaller
{

    [SerializeField] private SubScenesHolder sub_scene_holder;

    public override void InstallBindings()
    {
        Container.
            Bind<SubScenesHolder>().
            FromInstance(sub_scene_holder).
            AsSingle();
    }
}
