using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Button : MonoBehaviour
{
    public GameObject textmanager; // 텍스트 매니저 

    public int Dialog_Content; // 내부 대화 내용
    public int Dialog_Name; // 내부 인물 이름
    public int Dialog_FinerContent; // 마지막 페이지

    TextManager gamemanager; // 재선헌 

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
        player = null; //다시 실행 방어

        Vector3 down = new Vector3(0, -0.001f, 0);

        while (Buttens)
        {
            yield return null;
            transform.position += down;
            temp += i;

            if (temp > 0.2f)
            {
                gamemanager = textmanager.GetComponent<TextManager>(); //참조를 위한 재선헌
                StartCoroutine(gamemanager.Dialogue(Dialog_Name, Dialog_Content, Dialog_FinerContent, false)); //코루틴 시작 함수
                Buttens = false;
            }
        }
    }

}
