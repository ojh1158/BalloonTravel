using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Change : MonoBehaviour
{
    public GameObject Change_Object;    //�ٲ� ������Ʈ ����Ʈ
    public GameObject Change2_Object;
    public GameObject Change3_Object;
    public GameObject Change4_Object;
    public GameObject Change5_Object;

    public int Talking_End; // ��ȭ �� ���ϱ�

    public bool roop;       // ���� üũ
    bool Roop;              // ���� ����

    int roop_int = 0;       // ���� ���� üũ��
    public int Roop_int;    // ���� ����


    int Talking = 0;                // ��ȭ ī��Ʈ
    bool Talking_End_bool = false;  // ��ȭ ����

    public void RoopTalking()
    {
        Roop = false;
        Change_object(false);
    }

    public void OnTriggerExit(Collider other)
    {
        Change_object(Talking_End_bool);
    }



    public void Change_object(bool Talking_End_bool)      // �ٲ�ġ�� �Լ�
    {
        if (Talking == Talking_End - 1)                   // ��ȭ ����
        {
            Talking_End_bool = true;
        }

        if (roop)   // ���� Ȱ��ȭ
        {
            if (roop && roop_int == 1)
            {
                Roop = true;
                roop_int = 0;
            }
            else if (roop && roop_int == 2)
            {
                Roop = true;
                roop_int = 0;
            }
            else if (roop && roop_int == 3)
            {
                Roop = true;
                roop_int = 0;
            }
            else if (roop && roop_int == 4)
            {
                Roop = true;
                roop_int = 0;
            }
            else if (roop && roop_int == 5)
            {
                Roop = true;
                roop_int = 0;
            }
        }



        if (!Talking_End_bool && !Roop)      //��ȭ �ѱ�
        {
            if (Talking == 0)
            {
                Change_Object.SetActive(false);
                Change2_Object.SetActive(true);
                Talking++;
                roop_int++;
            }
            else if (Talking == 1)
            {
                Change2_Object.SetActive(false);
                Change3_Object.SetActive(true);
                Talking++;
                roop_int++;
            }
            else if (Talking == 2)
            {
                Change3_Object.SetActive(false);
                Change4_Object.SetActive(true);
                Talking++;
                roop_int++;
            }
            else if (Talking == 3)
            {
                Change4_Object.SetActive(false);
                Change5_Object.SetActive(true);
            }

        }        
    }
}
