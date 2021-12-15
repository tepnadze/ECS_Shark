using System;
using UnityEngine;

public class JoystickInputService : MonoBehaviour
{
    [SerializeField] private Joystick joystick;

    public static JoystickInputService instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    
    public bool isPressed() => Input.GetMouseButton(0);
    public Vector3 getJoystickPosition()
    {
        var pos = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);
        return pos;
    }
}
