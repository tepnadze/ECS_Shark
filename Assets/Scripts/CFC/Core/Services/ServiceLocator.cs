using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class ServiceLocator : MonoBehaviour
{
    #region SERILIZE_FIELDS

    [Header("SERVICES LINKS")]

     private JoystickInputService joystick_input_service = null;
    #endregion

    #region PRIVATE_FIELDS

    private IDictionary<object, object> services_dictionary = null;

    #endregion


    [Inject]
    public void onConstructor(JoystickInputService joystickInputService) {

        joystick_input_service = joystickInputService;
      
        initServices(null);
       
    }

  
    public async void initServices(Action callback)
    {

        await Task.Run((() =>
        {
            services_dictionary = new Dictionary<object, object>();

            services_dictionary.Add(typeof(JoystickInputService), joystick_input_service);

         
        }));

        Debug.Log("Service Initialized Status : <color=green> SUCCESS </color>");
        callback?.Invoke();
    }

    public T service<T>()
    {
        if (services_dictionary == null && !services_dictionary.ContainsKey(typeof(T)))
            return default;


        return (T)services_dictionary[typeof(T)];
    }
}
