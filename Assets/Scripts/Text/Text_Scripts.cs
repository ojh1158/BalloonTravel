using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Scripts : MonoBehaviour
{

    public GameObject textmanager; // �ؽ�Ʈ �Ŵ��� 

    public int Dialog_Content; // ���� ��ȭ ����
    public int Dialog_Name; // ���� �ι� �̸�
    public int Dialog_FinerContent; // ������ ������

    TextManager gamemanager;

    public  void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.isTalking = true;
            gamemanager = textmanager.GetComponent<TextManager>(); //������ ���� �缱��
            StartCoroutine(gamemanager.Dialogue(Dialog_Name, Dialog_Content, Dialog_FinerContent)); //�ڷ�ƾ ���� �Լ�
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
              
        }
    }
}
