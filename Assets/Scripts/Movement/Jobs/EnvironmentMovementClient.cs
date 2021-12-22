using Unity.Burst;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class EnvironmentMovementClient : MonoBehaviour
{

    [SerializeField] private Transform [] environment_movement_objects_array;

    private TransformAccessArray   transform_access_array;
    private JobHandle              environment_job_handle;


    private void Update() => movementJobLogic();

    private void LateUpdate() => transform_access_array.Dispose();

    private void movementJobLogic()
    {

        transform_access_array = new TransformAccessArray(environment_movement_objects_array.Length);

        foreach (var object_transform in environment_movement_objects_array)
        {
            if(object_transform != null)
                transform_access_array.Add(object_transform);
        }



        var environment_job = new EnvironmentMovementJob
        {
            target_position = Vector3.zero,
            speed = 2f,
            delta_time = Time.deltaTime
        };

        environment_job_handle = environment_job.Schedule(transform_access_array, default(JobHandle));
        environment_job_handle.Complete();
    }
    
}

[BurstCompile]
public struct EnvironmentMovementJob : IJobParallelForTransform
{

    public Vector3 target_position;
    public float   speed;
    public float   delta_time;
    
    public void Execute(int index, TransformAccess transform)
    {

        var direction = target_position - transform.position;
        transform.position += (direction * speed) * delta_time;
    }
} 