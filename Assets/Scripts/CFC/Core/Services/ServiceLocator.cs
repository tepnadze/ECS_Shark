using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class ServiceLocator : SingletonBase<ServiceLocator>
{


    #region PRIVATE_FIELDS

    private JoystickInputService     joystick_input_service      = null;
    private SpawnPlayerMemberService spawn_player_member_service = null;
    private MonoInitService          mono_init_service           = null;
  

    private IDictionary<object, object> services_dictionary = null;

    #endregion


    [Inject]
    public void onConstructor(JoystickInputService joystickInputService , SpawnPlayerMemberService spawnPlayerMemberService) {

        joystick_input_service      = joystickInputService;
        spawn_player_member_service = spawnPlayerMemberService;
        mono_init_service           = new MonoInitService();
        
        initServices(null);

    }

  
    public void initServices(Action callback)
    {

       services_dictionary = new Dictionary<object, object>();
       services_dictionary.Add(typeof(JoystickInputService)     , joystick_input_service);
       services_dictionary.Add(typeof(SpawnPlayerMemberService) , spawn_player_member_service);
       services_dictionary.Add(typeof(MonoInitService)          , mono_init_service);

        callback?.Invoke();
    }

    public T service<T>()
    {
        if (services_dictionary == null && !services_dictionary.ContainsKey(typeof(T)))
            return default;


        return (T)services_dictionary[typeof(T)];
    }
}
