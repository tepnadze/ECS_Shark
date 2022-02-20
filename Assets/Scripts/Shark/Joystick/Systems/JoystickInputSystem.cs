using Unity.Entities;
using UnityEngine;

public class JoystickInputSystem : SystemBase
{
    private JoystickInputService joystick_service = null;
    private ServiceLocator       service_locator  = null;
   
    private Vector3              joystick_position = Vector3.zero;


    protected override void OnStartRunning()
    {
        service_locator  = Object.FindObjectOfType<ServiceLocator>();
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
