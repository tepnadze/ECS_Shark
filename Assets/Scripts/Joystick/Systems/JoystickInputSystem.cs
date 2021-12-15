using Unity.Entities;
using UnityEngine;


public class JoystickInputSystem : SystemBase
{
    private Vector3 joystick_position = Vector3.zero;
    
    protected override void OnUpdate()
    {
        if (JoystickInputService.instance != null)
            joystick_position = JoystickInputService.instance.getJoystickPosition();
        
        Entities.ForEach((ref JoystickInputData joystick_data) =>
        {
            joystick_data.xPos = joystick_position.x;
            joystick_data.zPos = joystick_position.z;
            
        }).WithoutBurst().Run();
    }
}
