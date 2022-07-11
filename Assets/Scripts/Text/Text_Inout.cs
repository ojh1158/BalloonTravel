using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Inout : MonoBehaviour
{
    public GameObject textmanager; // ���� �Ŵ��� 

    public int Dialog_Content; // ���� ��ȭ ����
    public int Dialog_Name; // ���� �ι� �̸�

    TextManager gamemanager; // �缱�� 

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            gamemanager = textmanager.GetComponent<TextManager>(); //������ ���� �缱��
            gamemanager.GetComponent<TextManager>().UI_null();
            StartCoroutine(gamemanager.Dialogue_Inout(Dialog_Content, Dialog_Name)); //�ڷ�ƾ ���� �Լ�
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            gamemanager = textmanager.GetComponent<TextManager>(); //������ ���� �缱��
            StartCoroutine(gamemanager.Stop_Dialogue()); //�ڷ�ƾ
            gamemanager.GetComponent<TextManager>().UI_null();
        }
    }

}
