using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Button_Trigger : MonoBehaviour
{
    public GameObject Trigger_Object;   // ���谡 �Ǵ� ������Ʈ

    public GameObject active_button;    // ����� Ǫ�� ���

    bool Button_active;                 // ��ư Ȱ��ȭ

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
