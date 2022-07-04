using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject Text_Ui; //대화창
    public Text text; //채팅
    public Text CharacterName; //캐릭터 이름
    public GameObject event_Chapters; // 판정 제거용
                
    int Dialog_Content = 0;
    int Dialog_Name = 0;

    public TextAsset txt;
    public int lineSize;
    public int rowSize;

    public GameObject Npc1;
    public GameObject Npc1_1;

    public void Event_1_1() 
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");

            Dialog_Content = 28;
            Dialog_Name = 28;

            Text_Ui.SetActive(true);
            text.text = data_Dialog[Dialog_Content]["Content"].ToString();
            CharacterName.text = data_Dialog[Dialog_Name]["Name"].ToString();
            Dialog_Content++;
            Dialog_Name++;
            Time.timeScale = 0f;
            StartCoroutine(EventText());
        
    }

    IEnumerator EventText()
    {   
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");         
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
                
                if (Dialog_Content == 37)
                {
                    Dialog_Content = 0;
                    Dialog_Name = 0;
                    Time.timeScale = 1f;
                    Text_Ui.SetActive(false);
                    event_Chapters.SetActive(false);
                    yield break;
                }
   
            }
        }

    }
    public void Event_1_Sing()
    {
        Text_Ui.SetActive(true);
        text.text = "↓ 인계 \n 마을 ↑";
        CharacterName.text = "표지판";
    }

    public void Event_1_Sing_Out()
    {
        Text_Ui.SetActive(false);
    }

    public void NPC1_1()
    {
        Text_Ui.SetActive(true);
        text.text = "문제를 까먹었니? \n'파인 애플의 색깔은?'";
        CharacterName.text = "주민1";
    }

    public void NPC1()
    {

        Time.timeScale = 0f;

        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");

        Dialog_Content = 39;
        Dialog_Name = 39;

        Text_Ui.SetActive(true);
        text.text = data_Dialog[Dialog_Content]["Content"].ToString();
        CharacterName.text = data_Dialog[Dialog_Name]["Name"].ToString();
        Dialog_Content++;
        Dialog_Name++;
        StartCoroutine(npc1());
    }

    IEnumerator npc1()
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");
        while (true)
        {
            yield return null;
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Dialog_Content++;
                Dialog_Name++;

                text.text = data_Dialog[Dialog_Content]["Content"].ToString();
                CharacterName.text = data_Dialog[Dialog_Name]["Name"].ToString();

                if (Dialog_Content == 55)
                {

                    Dialog_Content = 0;
                    Dialog_Name = 0;
                    Time.timeScale = 1f;
                    Text_Ui.SetActive(false);
                    Npc1.SetActive(false);
                    Npc1_1.SetActive(true);

                }


            }
        }
    }





    void Update()
    {

    }


}
