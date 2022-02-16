using System.Collections;
using UnityEngine;

public class QuickCodeTesting : MonoBehaviour
{

    private SpawnPlayerMemberService service;


    private void Start()
    {
        StartCoroutine(testing());
      
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            for (int i = 0; i < 300; i++)
            {
                service.generatePlayerMember();
            }
        }
    }

    private IEnumerator testing()
    {

        yield return new WaitForSeconds(2f);

        service = ServiceLocator.instance.service<SpawnPlayerMemberService>();
    }
}
