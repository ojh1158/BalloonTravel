using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{

    public GameObject GameStart_Ui;
    public Image Fade;
 
    float fadeCount = 1.0f; //초기화 알파갚 최대


    void Start()
    {
        
    }

    // Update is called once per frame  
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log("버튼클릭");
            StartCoroutine(FadeCoroutine()); // -3000루틴
        }
   
    }
    IEnumerator FadeCoroutine() // -3000
    {
        
        //Debug.Log("코루틴 발동");
        while (fadeCount > 0.0f) //알파가 뒤질때까지 내림
        {
            fadeCount -= 0.005f; 
            yield return new WaitForSeconds(0.01f); //0.01초마다 실행
            Fade.color = new Color(0, 0, 0, fadeCount); //알파갚 무지성 하락
            if (fadeCount < 0.0f)
            {
                GameStart_Ui.gameObject.SetActive(false);
            }
        }
    }
}
