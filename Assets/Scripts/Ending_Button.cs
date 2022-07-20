using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending_Button : MonoBehaviour
{
    public GameObject door;

    
    public void OnTriggerEnter(Collider other)
    {
        GameManager.isTalking = true;
        StartCoroutine(Button_down());
    }

    IEnumerator Button_down()
    {
        while (true)
        {
            float down = 0.001f;
            yield return new WaitForSeconds(0.01f);
            transform.position -= new Vector3(0, down, 0);
            if (transform.position.y > 0.2f)
            {
                GameManager.isTalking = false;
                door.GetComponent<Door>().Door_open();
                yield break;
            }
        }
        
        
    }
}
