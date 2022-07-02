using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject Text_Ui; //대화창
    public Text text; //채팅
    public Text CharacterName; //캐릭터 이름
    public bool isAction; //이건 미정 
    public GameObject event_Chapters; // 판정 제거용

    public int Event_Chapters1_1;
                
    int Dialog_Content = 0;
    int Dialog_Name = 0;

    public TextAsset txt;
    public int lineSize;
    public int rowSize;

    void Start() 
    {
        
    }
    public void Event_1_1() 
    {  
        {
            Text_Ui.SetActive(true);
            text.text = "테스트";
            CharacterName.text = "주인공 이름";
            Time.timeScale = 0f;
            StartCoroutine(EventText());
        }
    }

    IEnumerator EventText()
    {   
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");         
        Event_Chapters1_1 = 0;
        //Debug.Log("코루틴 시작 부분");
        while (true)
        { 
            yield return null;
            if (Input.GetKeyDown(KeyCode.Z))
            {

                Dialog_Content++;
                Dialog_Name++;

                text.text = data_Dialog[Dialog_Content]["Content"].ToString();
                CharacterName.text = data_Dialog[Dialog_Name]["Name"].ToString();
                
                if (Dialog_Content == 7)
                {
                    Dialog_Content = 0;
                    Dialog_Name = 0;
                    Time.timeScale = 1f;
                    Text_Ui.SetActive(false);
                    event_Chapters.SetActive(false);

                }
   
            }
        }

    }


    void Update()
    {

    }


}
