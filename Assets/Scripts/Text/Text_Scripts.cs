using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Scripts : MonoBehaviour
{

    public GameObject textmanager; // �ؽ�Ʈ �Ŵ��� 

    public GameObject not_again;

    public int Dialog_Content; // ���� ��ȭ ����
    public int Dialog_Name; // ���� �ι� �̸�
    public int Dialog_FinerContent; // ������ ������

    public bool not_agine_Talk;
    bool nop;

    TextManager gamemanager;

    public  void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !nop)
        {
            GameManager.isTalking = true;
            gamemanager = textmanager.GetComponent<TextManager>(); //������ ���� �缱��
            StartCoroutine(gamemanager.Dialogue(Dialog_Name, Dialog_Content, Dialog_FinerContent)); //�ڷ�ƾ ���� �Լ�
            if (not_agine_Talk)
            {
                nop = true;
            }
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
              
        }
    }
    IEnumerator Num()
    {
        int i = 0;
        while (true)
        {
            yield return null;
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                i++;
                if (i == Dialog_FinerContent +2)
                {

                    not_again.SetActive(false);
                    yield break;
                }
            }
        }
    }
}
