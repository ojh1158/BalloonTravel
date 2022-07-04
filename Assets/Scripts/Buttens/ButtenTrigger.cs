using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtenTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(buttenManager());
        }
    }

    public void buttenexit()
    {
        StopCoroutine(buttenManager());
    }

    IEnumerator buttenManager()
    {
        float i = 0.001f;
        float b = 0f;

        while(b > -1f)
        {
            yield return null;
            transform.position += new Vector3(0, b - i, 0);


        }
    }
}
