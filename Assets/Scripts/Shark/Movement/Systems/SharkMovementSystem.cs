using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[UpdateAfter(typeof(JoystickInputSystem))]
public class SharkMovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
      //  sharkTranslation();
       // sharkRotation();
    }

    private void sharkRotation()
    {
        Entities.ForEach((ref Rotation rotation, ref JoystickInputData joystick_input) =>
        {
            if (joystick_input.xPos == 0 && joystick_input.zPos == 0) return;
            
            var pos                    = new float3(joystick_input.xPos, 0f, joystick_input.zPos);
            var look_rotation          = quaternion.LookRotation(pos, math.up());

            rotation.Value             = math.slerp(rotation.Value, look_rotation, Time.DeltaTime * 4f);
            
        }).WithoutBurst().Run();
    }

    private void sharkTranslation()
    {
        Entities.ForEach((ref Translation translation, ref JoystickInputData joystick_input) =>
        {
            translation.Value += new float3(joystick_input.xPos, 0f, joystick_input.zPos) * Time.DeltaTime * 4f;
        }).WithoutBurst().Run();
    }
}
