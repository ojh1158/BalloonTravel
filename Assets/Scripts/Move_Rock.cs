using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Rock : MonoBehaviour
{

    public void Rock_move()
    {
        StartCoroutine(move());
    }

    IEnumerator move()
    {
        float i = 0f;
        while (true)
        {
            yield return null;
            i++;
            transform.position += Vector3.back * 0.005f;
            if (i == 1200)
            {
                yield break;
            }
             
        }
         
    }
}
