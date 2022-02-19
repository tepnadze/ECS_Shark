using System.Collections;
using UnityEngine;

public class QuickCodeTesting : MonoBehaviour , IServiceInitSubscriber
{

    private SpawnPlayerMemberService service;


    private void Awake()
    {
        InterfaceEventsService.subscribe(this);
    }

    private void OnDestroy()
    {
        InterfaceEventsService.deSubscribe(this);
    }

  

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && !ReferenceEquals(service , null))
        {
            service.generatePlayerMember();
          
        }
    }

 

  

    public void onGetServices()
    {
        service = ServiceLocator.instance.service<SpawnPlayerMemberService>();
    }
}
