using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Button_Trigger : MonoBehaviour
{
    public GameObject Trigger_Object;   // 열쇠가 되는 오브젝트

    public GameObject active_button;    // 잠금을 푸는 대상

    bool Button_active;                 // 버튼 활성화

    public void OnTriggerEnter(Collider other)
    {
        Button_active = active_button.GetComponent<Text_Button>().Button_Actvie; 

        if (Button_active)
        {
            Trigger_Object.GetComponent<Text_Change>().roop = false;
            Trigger_Object.GetComponent<Text_Change>().RoopTalking();
        }
        
    }
}
