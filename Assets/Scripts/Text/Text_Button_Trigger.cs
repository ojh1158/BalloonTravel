using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Button_Trigger : MonoBehaviour
{
    public GameObject Target_Object; // 해당 오브젝트 부모 넣기

    public GameObject button_active;

    bool Button_active;

    public void OnTriggerEnter(Collider other)
    {
        Button_active = button_active.GetComponent<Text_Button>().Button_Actvie; 

        if (Button_active)
        {
            Target_Object.GetComponent<Text_Change>().roop = false;
            Target_Object.GetComponent<Text_Change>().RoopTalking();
        }
        
    }
}
