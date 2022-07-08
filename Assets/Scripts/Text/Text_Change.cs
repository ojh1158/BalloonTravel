using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Change : MonoBehaviour
{
    public GameObject Change_Object;
    public GameObject Change2_Object;
    public GameObject Change3_Object;
    public GameObject Change4_Object;
    public GameObject Change5_Object;

    public int Talking_End;
    int Talking = 0;
    public bool Talking_End_bool = false;
    public bool roopTalking;

    public int Trigger = 0; 

    public void OnTriggerExit(Collider other)
    {
        Change_object(Talking_End_bool, roopTalking);
    }

    public void Change_object(bool Talking_End_bool, bool roopTalking)     // 바꿔치기 함수
    {        
        if (Talking == Talking_End - 1)
        {
            Talking_End_bool = true;
            //Debug.Log("대화 끝" + roopTalking);
            Change_Object.SetActive(false);
            Change2_Object.SetActive(false);
            Change3_Object.SetActive(false);
            Change4_Object.SetActive(false);
            Change5_Object.SetActive(false);
        }

        if (roopTalking == false)
        {
            if (Talking == 0)
            {
                //Debug.Log("대화"+ roopTalking);
                Change_Object.SetActive(false);
                Change2_Object.SetActive(true);
                Talking++;
            }
            else if (Talking == 1)
            {
                //Debug.Log("대화" + roopTalking);
                Change2_Object.SetActive(false);
                Change3_Object.SetActive(true);
                Talking++;
            }
            else if (Talking == 2)
            {
                //Debug.Log("대화" + roopTalking);
                Change3_Object.SetActive(false);
                Change4_Object.SetActive(true);
                Talking++;
            }
            else if (Talking == 3)
            {
                //Debug.Log("대화" + roopTalking);
                Change4_Object.SetActive(false);
                Change5_Object.SetActive(true);
                Talking++;
            }

        }
        if (Talking_End_bool == true)
        {
            
        }
    }
}
