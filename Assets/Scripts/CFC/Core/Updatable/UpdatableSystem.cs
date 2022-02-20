using System.Collections.Generic;

public class UpdatableSystem : SingletonBase<UpdatableSystem>
{

    private readonly List<IUpdatable> updatables_list = new List<IUpdatable>();

   

    public void subscribe(IUpdatable updatable) {
        
        if (!updatables_list.Contains(updatable)) 
            updatables_list.Add(updatable);   
    }

    public void desubscribe(IUpdatable updatable) {
      
        if (updatables_list.Contains(updatable))
            updatables_list.Remove(updatable);      
    }

    private void Update()
    {
        if (updatables_list.Count > 0)
        {
            for (int i = 0; i < updatables_list.Count; i++)
                updatables_list[i].onUpdate();
            
        }
    }
}
