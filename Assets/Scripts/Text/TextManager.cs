using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public static bool isJumped = false;
    public static bool isTalking = false;

    public Text text; // 대화창 내용
    public Text CharacterName; // 인물 이름
    Text charater; //캐릭터

    public GameObject Text_Ui; // 대화창 UI
    public GameObject text_Change; // 개채 참조

    public GameObject Main_character_nomal;
    public GameObject Main_character_happy;
    public GameObject Main_character_surprised;
    public GameObject Main_character_bed;

    void Update()
    {

    }

    public IEnumerator Stop_Dialogue() //다이얼로그 멈춤
    {
        yield return null;
        Text_Ui.SetActive(false);
        StopAllCoroutines();
        yield break;
    }

    public IEnumerator Dialogue_Inout(int Content, int Name) // 다이얼로그 인_아웃 대화 스크립트
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");
        Text_Ui.SetActive(true);

        CharacterName.text = data_Dialog[Content]["Name"].ToString();
        StartCoroutine(Typing(text, data_Dialog[Name]["Content"].ToString()));
        StartCoroutine(Text_UI_image(Content));
        yield break;
    }
    public IEnumerator Typing(Text typingText, string message)
    {
        for (int i = 0; i < message.Length; i++)
        {
            yield return null;
            typingText.text = message.Substring(0, i + 1);
            if (Input.GetKeyDown(KeyCode.Z))
            {
                yield break;
            }
        }

    }



    public IEnumerator Dialogue(int Content, int Name, int FinerContent) // 다이얼로그 대화 스크립트
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");
        Text_Ui.SetActive(true);

        CharacterName.text = data_Dialog[Name]["Name"].ToString();
        StartCoroutine(Typing(text, data_Dialog[Content]["Content"].ToString()));
        StartCoroutine(Text_UI_image(Content));

        while (true)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
            {
                Content++;
                Name++;

                Main_character_nomal.SetActive(false);
                Main_character_happy.SetActive(false);
                Main_character_bed.SetActive(false);
                Main_character_surprised.SetActive(false);

                CharacterName.text = data_Dialog[Name]["Name"].ToString();
                StartCoroutine(Typing(text, data_Dialog[Content]["Content"].ToString()));
                StartCoroutine(Text_UI_image(Content));

                if (Content == FinerContent + 1 || Input.GetKeyDown(KeyCode.Z) && Input.GetMouseButtonDown(0))
                {
                    Text_Ui.SetActive(false);
                    GameManager.isTalking = false;
                    //text_change.GetComponent<Text_Change>().RoopTalking(roopTalking);
                    yield break;
                }
            }
        }
    }
    IEnumerator Text_UI_image(int Content)
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");


        while (true)
        {
            yield return null;
            string charater = data_Dialog[Content]["UI"].ToString();

            if (charater == "Main_character_nomal")
            {
                Main_character_nomal.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
                {
                    Main_character_nomal.SetActive(false);
                }
                yield break;
            }
            if (charater == "Main_character_happy")
            {
                Main_character_happy.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
                {
                    Main_character_happy.SetActive(false);
                }
                yield break;
            }
            if (charater == "Main_character_bed")
            {
                Main_character_bed.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
                {
                    Main_character_bed.SetActive(false);
                }
                yield break;
            }
            if (charater == "Main_character_surprised")
            {
                Main_character_surprised.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
                {
                    Main_character_surprised.SetActive(false);
                }
                yield break;
            }

        }

    }
}
