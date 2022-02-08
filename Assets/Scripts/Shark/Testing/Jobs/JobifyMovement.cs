using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public struct EcsMovementJob : IJobForEach<Translation, JobPosition>
{
    public float dt;
    public void Execute(ref Translation translation, ref JobPosition job_position)
    {
        translation.Value += math.right() * 2f *dt ;
    }
}

public class JobifyMovement : JobComponentSystem
{
  

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new EcsMovementJob()
        {
            dt = Time.DeltaTime
        };

        return job.Schedule(this,inputDeps);
    }
}