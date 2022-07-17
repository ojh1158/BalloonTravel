using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAni : MonoBehaviour
{
   
    public GameObject star_ain;
    public GameObject back;
    public GameObject[] star_get;

    public int Dialog_Content; // 내부 대화 내용
    public int Dialog_Name; // 내부 인물 이름
    public int Dialog_FinerContent; // 마지막 페이지

    public GameObject textmanager;
    TextManager gamemanager;

    int star_get_int = 0;



    public void Star_Get()
    {
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        back.SetActive(true);
        star_ain.SetActive(true);
        yield return new WaitForSeconds(3f);
        back.SetActive(false);
        star_ain.SetActive(false);
        Debug.Log(star_get_int);
        star_get[star_get_int].SetActive(true);
        yield return new WaitForSeconds(0.7f);
        StartCoroutine(Start_Talk());
        star_get_int++;
    }

    IEnumerator Start_Talk()
    {
        yield return null;
        gamemanager = textmanager.GetComponent<TextManager>();                                      //참조를 위한 재선헌
        StartCoroutine(gamemanager.Dialogue(Dialog_Name, Dialog_Content, Dialog_FinerContent));     //코루틴 시작 함수
    }
    
}
