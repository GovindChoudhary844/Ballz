using UnityEngine;

public class Instantiater : MonoBehaviour
{
    public GameObject ballPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(ballPrefab, transform.position, transform.rotation);
        }
    }
}
