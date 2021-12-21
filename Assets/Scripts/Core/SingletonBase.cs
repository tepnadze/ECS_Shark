using UnityEngine;

public abstract class SingletonBase<T> : MonoBehaviour where T : class
{
   private  static T _instance;

   public  static T instance
   {
      get
      {
         if (_instance == null)
         {
            Debug.Log("Instance is null");
         }
         return _instance;
      }
   }

   public virtual void Awake()
   {
      if (_instance == null)
         _instance = this as T;
   }
}
