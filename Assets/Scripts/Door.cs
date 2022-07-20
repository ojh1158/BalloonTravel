using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject[] Del;

    public GameObject[] door_Ain;

    public void Door_open()
    {
        StartCoroutine(door_op());
    }

    IEnumerator door_op()
    {
        yield return null;
        Del[0].SetActive(false);
        Del[1].SetActive(false);

        door_Ain[0].SetActive(true);
        door_Ain[1].SetActive(true);

        // 여기서부터 내려오는 애니메이        
    }

    // 16, 22

}
