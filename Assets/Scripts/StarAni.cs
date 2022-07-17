using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAni : MonoBehaviour
{
   
    public GameObject star_ain;
    public GameObject back;
    public GameObject[] star_get;

    public int Dialog_Content; // ���� ��ȭ ����
    public int Dialog_Name; // ���� �ι� �̸�
    public int Dialog_FinerContent; // ������ ������

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
        gamemanager = textmanager.GetComponent<TextManager>();                                      //������ ���� �缱��
        StartCoroutine(gamemanager.Dialogue(Dialog_Name, Dialog_Content, Dialog_FinerContent));     //�ڷ�ƾ ���� �Լ�
    }
    
}
