using UnityEngine;

public abstract class MonoBase : MonoBehaviour , IUpdatable
{

    private void Start()     => ServiceLocator.instance.service<MonoInitService>().subscribe(this);
    
    private void OnDestroy() => ServiceLocator.instance.service<MonoInitService>().deSubscribe(this);
    


    public virtual void init()      =>    UpdatableSystem.instance.subscribe(this);
    public virtual void onDestroy() =>    UpdatableSystem.instance.desubscribe(this);
    public virtual void onUpdate() { }
}

public interface IUpdatable {

    void onUpdate();
}
