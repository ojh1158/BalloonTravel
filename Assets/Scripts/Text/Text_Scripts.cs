using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Scripts : MonoBehaviour
{
    public GameObject Rock_4;

    public GameObject talking_int;

    public GameObject textmanager;  // �ؽ�Ʈ �Ŵ��� 

    public GameObject not_again;

    public int Dialog_Content;      // ���� ��ȭ ����
    public int Dialog_Name;         // ���� �ι� �̸�
    public int Dialog_FinerContent; // ������ ������

    public bool not_agine_Talk;
    bool nop;
    bool move;
    int i = 0;

    TextManager gamemanager;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !nop)
        {
            GameManager.isTalking = true;
            ++i;
            gamemanager = textmanager.GetComponent<TextManager>(); //������ ���� �缱��
            StartCoroutine(gamemanager.Dialogue(Dialog_Name, Dialog_Content, Dialog_FinerContent)); //�ڷ�ƾ ���� �Լ�
            StartCoroutine(Count());
            if (not_agine_Talk)
            {
                nop = true;
                talking_int.GetComponent<Talk_int>().page_();
            }
 
        }
    }
    IEnumerator Count()
    {

        while (true)
        {
            yield return null;
            if (Input.GetKeyDown(KeyCode.Space) && Input.GetMouseButtonDown(0))
            {
                 Dialog_Content++;
            }

            if (Dialog_Content == Dialog_FinerContent + 2 && i == 2)
            {
                move = true;
                yield return null;
            }
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (move)
        {
            Rock_4.GetComponent<Move_Rock>().Rock_move();
        }
    }
}
