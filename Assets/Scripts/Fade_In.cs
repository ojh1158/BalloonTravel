using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade_In : MonoBehaviour
{

    public GameObject GameStart_Ui;
    public Image Fade;
 
    float fadeCount = 1.0f; //�ʱ�ȭ ���İ� �ִ�


    void Start()
    {
        StartCoroutine(FadeCoroutine()); 
    }
    IEnumerator FadeCoroutine()
    {
        
        while (fadeCount > 0.0f) 
        {
            fadeCount -= 0.005f; 
            yield return new WaitForSeconds(0.01f); //0.01�ʸ��� ����
            Fade.color = new Color(0, 0, 0, fadeCount); 
            if (fadeCount < 0.0f)
            {
                GameStart_Ui.gameObject.SetActive(false);
                yield break;
            }
        }
    }
}
