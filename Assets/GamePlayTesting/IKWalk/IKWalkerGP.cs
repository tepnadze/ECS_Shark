using UnityEngine;
using UnityEngine.Animations.Rigging;

public class IKWalkerGP : MonoBehaviour
{

    [SerializeField] private Transform left_foot_ray_point;
    [SerializeField] private Transform right_foot_ray_point;

    [SerializeField] private Transform left_foot_target;
    [SerializeField] private Transform right_foot_target;

    [SerializeField] private Rig left_rig;
    [SerializeField] private Rig right_rig;

    
    [SerializeField] private LayerMask platform_layer_mask;






    private void Update()
    {

        ForwardWalking();

        PlatformChecker(left_foot_ray_point.position  + (Vector3.forward / 2f) + Vector3.up , left_rig   , left_foot_target);
        PlatformChecker(right_foot_ray_point.position + (Vector3.forward / 2f) + Vector3.up , right_rig  , right_foot_target);
    }

    private void PlatformChecker(Vector3 start_point , Rig rig, Transform foot_transform) {

        var can_step = Physics.Raycast(new Ray(transform.TransformPoint(start_point), Vector3.down), out var hit , 2f , platform_layer_mask);
       
        if (can_step)
            SetStepPosition(rig, hit.point , foot_transform);
        else
            rig.weight = 0f;

    }

    private void SetStepPosition(Rig rig, Vector3 position,Transform foot_transform)  
    {

        rig.weight = 1f;
        foot_transform.position = position;
    }

    private void ForwardWalking() => transform.position += Vector3.forward * Time.deltaTime * 0.5f;
}
