using Unity.Scenes;
using UnityEngine;

public class SubScenesHolder : SingletonBase<SubScenesHolder>
{

   [SerializeField] private SubScene sub_scene;
   
   
   public SubScene subScene => sub_scene;
}
