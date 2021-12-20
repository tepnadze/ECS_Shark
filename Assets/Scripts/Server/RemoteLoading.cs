using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class RemoteLoading : MonoBehaviour
{
   [SerializeField] private string asset_labels;


   private void Start()
   {
      loadObjects(asset_labels);
   }

   private async void loadObjects(string labels)
   { 
      var tasks = await Addressables.LoadResourceLocationsAsync(labels).Task;
      foreach (var remote_tasks in tasks)
      {
         await Addressables.InstantiateAsync(remote_tasks).Task;
      }
   }
}
