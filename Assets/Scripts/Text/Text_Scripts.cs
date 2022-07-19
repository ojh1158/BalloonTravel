using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Scripts : MonoBehaviour
{
    public GameObject Rock_4;

    public GameObject talking_int;

    public GameObject textmanager;  // 텍스트 매니져 

    public GameObject not_again;

    public int Dialog_Content;      // 내부 대화 내용
    public int Dialog_Name;         // 내부 인물 이름
    public int Dialog_FinerContent; // 마지막 페이지

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
            gamemanager = textmanager.GetComponent<TextManager>(); //참조를 위한 재선헌
            StartCoroutine(gamemanager.Dialogue(Dialog_Name, Dialog_Content, Dialog_FinerContent)); //코루틴 시작 함수
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
