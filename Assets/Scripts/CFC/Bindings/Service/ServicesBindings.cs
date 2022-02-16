using UnityEngine;
using Zenject;

public class ServicesBindings : MonoInstaller 
{

    [SerializeField] private ServiceLocator service_locator;


    public override void InstallBindings()
    {
        Container.Bind<SpawnPlayerMemberService>().FromInstance(new SpawnPlayerMemberService()).AsSingle();
        Container.Bind<JoystickInputService>()    .FromInstance(new JoystickInputService()).AsSingle();
        Container.Bind<ServiceLocator>()          .FromInstance(service_locator);
    }
}
