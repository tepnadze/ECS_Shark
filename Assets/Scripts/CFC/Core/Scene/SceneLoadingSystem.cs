using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class SceneLoadingSystem : MonoBehaviour
{

    #region  PRIVATE FIELDS

    private AsyncOperationHandle<SceneInstance> scene_handle;
    #endregion


    private void Awake()
    {
        LoadScene("TestingScene", LoadSceneMode.Additive);
    }

    private void LoadScene(object tESTING_SCENE, LoadSceneMode additive)
    {
        throw new NotImplementedException();
    }

    private void LoadScene(string sceneAddress, LoadSceneMode sceneMode)
    {
        Addressables.LoadSceneAsync(sceneAddress, sceneMode).Completed += delegate (AsyncOperationHandle<SceneInstance> handle)
        {
            if (handle.Status != AsyncOperationStatus.Succeeded) return;

            Debug.Log($"<color=green> SCENE LOADED : { handle.Result.Scene.name } </color>");
            scene_handle = handle;

            ServiceLocator.instance.service<MonoInitService>().initMono();
        };
    }

    private void UnloadScene()
    {
        Addressables.UnloadSceneAsync(scene_handle, true).Completed += handle =>
        {
            if (handle.Status != AsyncOperationStatus.Succeeded) return;
          
        };
    }
}
