using Unity.Entities;
using UnityEngine;


[GenerateAuthoringComponent]
public struct JoystickInputData : IComponentData
{
  [HideInInspector] public float xPos;
  [HideInInspector] public float zPos;
}
