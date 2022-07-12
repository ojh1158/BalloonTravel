using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Button : MonoBehaviour
{
    public GameObject textmanager; // �ؽ�Ʈ �Ŵ��� 
    public GameObject player; // �÷��̾� �ű�� �뵵

    public int Dialog_Content; // ���� ��ȭ ����
    public int Dialog_Name; // ���� �ι� �̸�
    public int Dialog_FinerContent; // ������ ������

    public bool Button_Actvie;
    public bool O; //���� ��ư
    public bool button_O = true;
    

    
    TextManager gamemanager; // �缱�� 

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Button_Actvie)
        {
            StartCoroutine(buttenManager());
            GameManager.isTalking = true;
            if (!button_O)
            {
                GameManager.isTalking = false;
            }
        }
    }
    IEnumerator buttenManager()
    {
        float i = 0.001f;
        float temp = 0f;

        Vector3 down = new Vector3(0, -0.001f, 0);
        if (!O)
        {
            while (true)
            {
                yield return null;
                transform.position += down;
                temp += i;

                if (temp > 0.2f)
                {
                    yield return new WaitForSeconds(0.5f);
                    player.GetComponent<Player_Button_Move>().move();

                    while (true)
                    {
                        yield return null;
                        transform.position -= down;
                        temp -= i;
                        if (temp < 0f)
                        {
                            gamemanager = textmanager.GetComponent<TextManager>();                                      //������ ���� �缱��
                            StartCoroutine(gamemanager.Dialogue(Dialog_Name, Dialog_Content, Dialog_FinerContent));     //�ڷ�ƾ ���� �Լ�
                            yield break;
                        }
                    }
                }
            }
        }
        if (O)
        {
            while (button_O)
            {
                yield return null;
                transform.position += down;
                temp += i;

                if (temp > 0.2f)
                {
                    gamemanager = textmanager.GetComponent<TextManager>();                                      //������ ���� �缱��
                    StartCoroutine(gamemanager.Dialogue(Dialog_Name, Dialog_Content, Dialog_FinerContent));     //�ڷ�ƾ ���� �Լ�
                    button_O = false;
                    Button_Actvie = false;
                    yield break;
                }
            }
        }

    }
}
