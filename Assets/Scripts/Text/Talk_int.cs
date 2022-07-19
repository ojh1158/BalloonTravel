using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk_int : MonoBehaviour
{
    public GameObject Talk_on_1;

    int page = 0;

    public void page_()
    {
        page++;
        if (page == 3)
        {
            StartCoroutine(page_3());
        }
    }

    IEnumerator page_3()
    {
        
        yield return null;
        Talk_on_1.SetActive(true);
    }
}
