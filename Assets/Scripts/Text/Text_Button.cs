using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Button : MonoBehaviour
{
    public GameObject textmanager; // �ؽ�Ʈ �Ŵ��� 

    public int Dialog_Content; // ���� ��ȭ ����
    public int Dialog_Name; // ���� �ι� �̸�
    public int Dialog_FinerContent; // ������ ������

    TextManager gamemanager; // �缱�� 

    string player = "Player";

    bool Buttens = true;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == player)
        {
            StartCoroutine(buttenManager());
            GameManager.isTalking = true;
        }
    }
    IEnumerator buttenManager()
    {
        float i = 0.001f;
        float temp = 0f;
        player = null; //�ٽ� ���� ���

        Vector3 down = new Vector3(0, -0.001f, 0);

        while (Buttens)
        {
            yield return null;
            transform.position += down;
            temp += i;

            if (temp > 0.2f)
            {
                gamemanager = textmanager.GetComponent<TextManager>(); //������ ���� �缱��
                StartCoroutine(gamemanager.Dialogue(Dialog_Name, Dialog_Content, Dialog_FinerContent, false)); //�ڷ�ƾ ���� �Լ�
                Buttens = false;
            }
        }
    }

}
