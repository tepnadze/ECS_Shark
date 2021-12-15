using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;


public class SharkMovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation , ref JoystickInputData joystick_input) =>
        {
            translation.Value += new float3(joystick_input.xPos, 0f, joystick_input.zPos);
        }).WithoutBurst().Run(); 
    }
}
