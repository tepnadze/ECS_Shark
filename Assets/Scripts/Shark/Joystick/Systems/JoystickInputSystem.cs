using System.Collections;
using Unity.Entities;
using UnityEngine;
using Zenject;

public class JoystickInputSystem : SystemBase
{
    private JoystickInputService joystick_service = null;
    private ServiceLocator       service_locator  = null;
   
    private Vector3              joystick_position = Vector3.zero;


    protected override void OnCreate()
    {
        base.OnCreate();

  
        service_locator  = Object.FindObjectOfType<ServiceLocator>();
        service_locator.StartCoroutine(getService());

    }

    private IEnumerator getService() {

        yield return null;
        joystick_service = service_locator.service<JoystickInputService>();
       
    }
    protected override void OnUpdate()
    {
        if (joystick_service != null)
        {
            joystick_position = joystick_service.getJoystickPosition();


            Entities.ForEach((ref JoystickInputData joystick_data) =>
            {
                joystick_data.xPos = joystick_position.x;
                joystick_data.zPos = joystick_position.z;

            }).WithoutBurst().Run();
        }
    }
}
