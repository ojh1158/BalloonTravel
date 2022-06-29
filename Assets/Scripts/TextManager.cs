using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{



    public GameObject Text_Ui; //대화창
    public Text text; //채팅
    public Text CharacterName; //캐릭터 이름
    public bool isAction; //이건 미정
    int clickCount = 0;//클릭횟수 카운터 


    void Start()
    {
        
    }

    public void TalkStart() 
    {
        Text_Ui.SetActive(true);
        clickCount = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (clickCount == 0)
            {
                text.text = "1번 텍스트 입니다";
                clickCount++;
            }

            else if (clickCount == 1)
            {
                text.text = "2번 텍스트 입니다";
                clickCount++;
            }

            else if (clickCount == 2)
            {
                text.text = "3번 텍스트 입니다";
                clickCount++;

            }
            else if (clickCount == 3)
            {
                text.text = "";
                Text_Ui.SetActive(false);
                clickCount = 0;
            }
        }



        
    }
}
