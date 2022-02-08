using System.Collections;
using UnityEngine;

public class PlacmentObjectTesting : MonoBehaviour
{
    [SerializeField] private GameObject point;
    [SerializeField] private GameObject radius_point;

    [SerializeField] private float      radius;



    private void Start()
    {
        StartCoroutine(generatePoint());
        StartCoroutine(generatePointRadius());
    }
    private IEnumerator generatePoint() {

        for (int i = 0; i < 2000; i++) {

            yield return null;

            var a = Random.Range(0, 1f);
            var b = Random.Range(0, 1f);

            if (b < a) {

                var temp = b;
                b = a;
                a = temp;
            }

            var pos = new Vector3 (
                b * radius * Mathf.Cos(2 * Mathf.PI * a / b),
                0f,
                b * radius * Mathf.Sin(2 * Mathf.PI * a / b));
            

            var new_point = Instantiate(point);


            new_point.transform.position = pos;
        }
    }

    private IEnumerator generatePointRadius()
    {

        for (int i = 0; i < 2000; i++)
        {

            yield return null;

            var new_point = Instantiate(radius_point);
            var angle = Random.Range(0f, 360f);

            var x_pos = Mathf.Cos(angle) * radius;
            var z_pos = Mathf.Sin(angle) * radius;

            new_point.transform.position = new Vector3(x_pos, 0f, z_pos);
        }
    }
}
