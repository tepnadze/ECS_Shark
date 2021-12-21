using UnityEngine;

public class JoystickInputService : SingletonBase<JoystickInputService>
{
    [SerializeField] private Joystick joystick;


    public bool isPressed() => Input.GetMouseButton(0);
    public Vector3 getJoystickPosition()
    {
        var pos = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);
        return pos;
    }
}
