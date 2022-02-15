using System.Collections;
using System.Threading.Tasks;
using UnityEngine;


public class JoystickInputService 
{
    private Joystick   joystick;
  

    public JoystickInputService() => loadEnum();
    

    private async void  loadEnum() {


        var load_holder = Resources.LoadAsync<GameObject>("PlayerJoystick");
       
        while (!load_holder.isDone) {
            await Task.Yield();
        }
        var prefab =  (GameObject) Object.Instantiate(load_holder.asset , Object.FindObjectOfType<Canvas>().transform);

        joystick =  prefab.GetComponent<Joystick>();

     
    }
    public bool isPressed() => Input.GetMouseButton(0);
    public Vector3 getJoystickPosition()
    {

        var pos = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);
      
        return pos;
    }
}
