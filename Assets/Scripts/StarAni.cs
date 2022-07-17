using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarAni : MonoBehaviour
{
   
    public GameObject star_ain;
    public GameObject back;
    public Image fade;
    public GameObject[] star_get;

    public int Dialog_Content; // ���� ��ȭ ����
    public int Dialog_Name; // ���� �ι� �̸�
    public int Dialog_FinerContent; // ������ ������

    public GameObject textmanager;
    TextManager gamemanager;

    bool isTlaking;

    float fadeCount = 0f;
    int star_get_int = 0;

    void Update()
    {
        if (isTlaking)
        {
            GameManager.isTalking = true;
        }
    }

    public void Star_Get()
    {
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        isTlaking = true;
        yield return new WaitForSeconds(0.5f);
        back.SetActive(true);
        star_ain.SetActive(true);
        yield return new WaitForSeconds(2.2f);
        back.SetActive(false);
        StartCoroutine(FadeCoroutine());
        star_ain.SetActive(false);
        Debug.Log(star_get_int);
        star_get[star_get_int].SetActive(true);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Start_Talk());
        star_get_int++;
    }

    IEnumerator Start_Talk()
    {
        yield return null;
        isTlaking = false;
        GameManager.isTalking = true;
        gamemanager = textmanager.GetComponent<TextManager>();                                      //������ ���� �缱��
        StartCoroutine(gamemanager.Dialogue(Dialog_Name, Dialog_Content, Dialog_FinerContent));     //�ڷ�ƾ ���� �Լ�
        
    }

    IEnumerator FadeCoroutine()
    {
        fadeCount = 1f;
        while (true)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);     //0.01�ʸ��� ����

            fade.color = new Color(255, 255, 255, fadeCount);
            if (fadeCount < 0.0f)
            {
                yield break;
            }
        }
    }
}
