using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Button_Trigger : MonoBehaviour
{
    public GameObject Trigger_Object;   // ���谡 �Ǵ� ������Ʈ

    public GameObject text_button;      // ��ư ��Ȱ��ȭ ������Ʈ
    public GameObject text_button2;
    public GameObject text_button3;
    public GameObject text_button4; 

    public GameObject active_button;    // ����� Ǫ�� ���

    bool Button_active;                 // ��ư Ȱ��ȭ

    public void OnTriggerEnter(Collider other)
    {
        Button_active = active_button.GetComponent<Text_Button>().Button_Actvie; 

        if (Button_active)
        {
            Trigger_Object.GetComponent<Text_Change>().roop = false;
            Trigger_Object.GetComponent<Text_Change>().RoopTalking();
            text_button.GetComponent<Text_Button>().Button_Actvie = false;
            text_button2.GetComponent<Text_Button>().Button_Actvie = false;
            text_button3.GetComponent<Text_Button>().Button_Actvie = false;
            text_button4.GetComponent<Text_Button>().Button_Actvie = false;
        }
        
    }
}
