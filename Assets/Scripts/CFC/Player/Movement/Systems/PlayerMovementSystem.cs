using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[UpdateAfter(typeof(JoystickInputSystem))]
public class PlayerMovementSystem : SystemBase
{

    private float2 joystick_data;


    protected override void OnUpdate()
    {
        setJoystickData();

        playerRotation();
        playerTranslation();
    }

    private void setJoystickData() {

        Entities.ForEach((ref JoystickInputData data) =>
        {
            joystick_data.x = data.xPos;
            joystick_data.y = data.zPos;

        }).WithoutBurst().Run();
    }
    private void playerRotation()
    {
        Entities.ForEach((ref Rotation rotation) =>
        {
            if (joystick_data.x == 0 && joystick_data.y == 0) return;

            var pos           = new float3(joystick_data.x , 0f , joystick_data.y);
            var look_rotation = quaternion.LookRotation(pos, math.up());

            rotation.Value    = math.slerp(rotation.Value, look_rotation, Time.DeltaTime * 4f);

        }).WithoutBurst().Run();
    }

    private void playerTranslation()
    {
        Entities.ForEach((ref Translation translation ) =>
        {
           
            translation.Value += new float3(joystick_data.x , 0f , joystick_data.y) * Time.DeltaTime * 4f;
       
        }).WithoutBurst().Run();
    }
}
