using Unity.Scenes;
using UnityEngine;

public class SubScenesHolder : MonoBehaviour
{

   [SerializeField] private SubScene sub_scene;
   
   
   public SubScene subScene => sub_scene;
   public static SubScenesHolder instance;

   private void Awake()
   {
      if (instance == null)
         instance = this;
   }
}
