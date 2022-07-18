using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarAni : MonoBehaviour
{
   
    public GameObject[] star_ain;
    public Image fade;

    public GameObject fade_in_go;
    public Image fade_in;


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
        fade_in_go.SetActive(true);
        StartCoroutine(FadeCoroutine_in());
        yield return new WaitForSeconds(1f);
        star_ain[star_get_int].SetActive(true);
        yield return new WaitForSeconds(1.7f);
        StartCoroutine(FadeCoroutine());
        star_get[star_get_int].SetActive(true);
        star_ain[star_get_int].SetActive(false);
        yield return new WaitForSeconds(1.5f);
        all_star_reset();
        StartCoroutine(Start_Talk());
        star_get_int++;
    }

    public void all_star_reset()
    {
        for (int i = 0; i < star_get_int + 1; i++)
        {
            Debug.Log(i);
            star_get[i].SetActive(false);
            star_get[i].SetActive(true);
        }
    }

    IEnumerator Start_Talk()
    {
        yield return null;
        isTlaking = false;
        fade_in_go.SetActive(false);
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

    IEnumerator FadeCoroutine_in()
    {
        fadeCount = 0f;
        while (true)
        {
            fadeCount += 0.02f;
            yield return new WaitForSeconds(0.01f);     //0.01�ʸ��� ����

            fade.color = new Color(0, 0, 0, fadeCount);
            if (fadeCount > 0.4f)
            {
                yield break;
            }
        }
    }
}
