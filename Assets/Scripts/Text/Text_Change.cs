using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Change : MonoBehaviour
{
    public GameObject[] Change_Object;    //�ٲ� ������Ʈ ����Ʈ

    public int Talking_End; // ��ȭ �� ���ϱ�

    public bool Roop;       // ���� üũ

    public bool Navar_stop_talking;
    [HideInInspector] public bool Roop_Talking;

    public int Roop_int;    // ���� ����


    int Talking = 0;                // ��ȭ ī��Ʈ
    bool Talking_End_bool = false;  // ��ȭ ����

    public void RoopTalking()
    {
        Roop = false;
        Talking_End_bool = false;
        Change_object();
        
    }

    public void OnTriggerExit(Collider other)
    {
        Change_object();
    }



    public void Change_object()      // �ٲ�ġ�� �Լ�
    {
        if (Talking_End_bool && !Navar_stop_talking)
        {
            Change_Object[Talking].SetActive(false);
        }

        if (Talking_End_bool && Navar_stop_talking)
        {

        }

        if (Roop)   // ���� Ȱ��ȭ
        {
            if (Roop_int == Talking)
            {
                Roop_Talking = true;
                Debug.Log("���� Ȱ��ȭ");
            }
        }

        if (!Talking_End_bool && !Roop_Talking)      //��ȭ �ѱ�
        {
            Change_Object[Talking].SetActive(false);
            Change_Object[Talking + 1].SetActive(true);
            Talking++;
        }

        if (Talking == Talking_End)                   // ��ȭ ����
        {
            Talking_End_bool = true;
        }

    }
}
