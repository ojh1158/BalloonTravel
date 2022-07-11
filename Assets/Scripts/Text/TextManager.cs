using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public static bool isJumped = false;
    public static bool isTalking = false;

    public Text text;           // 대화창 내용
    public Text CharacterName;  // 인물 이름

    public GameObject Text_Ui;      // 대화창 UI
    public GameObject text_Change;  // 개채 참조

    public GameObject Main_character_nomal;
    public GameObject Main_character_happy;
    public GameObject Main_character_surprised;
    public GameObject Main_character_bed;

    public GameObject Main_character_nomal_Fade;
    public GameObject Main_character_happy_Fade;
    public GameObject Main_character_surprised_Fade;
    public GameObject Main_character_bed_Fade;

    public GameObject pilia_nomal;
    public GameObject pilia_happy;
    public GameObject pilia_Sad;
    public GameObject pilia_Curiosity;
    public GameObject pilia_Panic;
    public GameObject pilia_Angry;
    public GameObject pilia_awe;




    public GameObject Color_Quiz;

    void Update()
    {

    }

    public IEnumerator Stop_Dialogue() //다이얼로그 멈춤
    {
        yield return null;
        Text_Ui.SetActive(false);
        UI_null();
        StopAllCoroutines();
        yield break;
    }

    public IEnumerator Dialogue_Inout(int Content, int Name) // 다이얼로그 인_아웃 대화 스크립트
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");
        Text_Ui.SetActive(true);
        Main_charater_Fade();
        UI_null();

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

        UI_null();

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

                UI_null();

                CharacterName.text = data_Dialog[Name]["Name"].ToString();
                StartCoroutine(Typing(text, data_Dialog[Content]["Content"].ToString()));
                StartCoroutine(Text_UI_image(Content));

                if (Content == FinerContent + 1 || Input.GetKeyDown(KeyCode.Z) && Input.GetMouseButtonDown(0))
                {
                    Text_Ui.SetActive(false);
                    GameManager.isTalking = false;
                    StopCoroutine(Text_UI_image(Content));
                    UI_null();
                    Main_charater_Fade();
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
            string Image = data_Dialog[Content]["Image"].ToString();

            if (Image == "Color_Quiz")
            {
                UI_null();
                Color_Quiz.SetActive(true);
            }
            if (charater == "Elphis_nomal")
            {
                UI_null();
                Main_charater_Fade();
                Main_character_nomal.SetActive(true);
                Main_character_nomal_Fade.SetActive(true);
            }
            if (charater == "Elphis_happy")
            {
                UI_null();
                Main_charater_Fade();
                Main_character_happy.SetActive(true);
                Main_character_happy_Fade.SetActive(true);
            }
            if (charater == "Elphis_bed")
            {
                UI_null();
                Main_charater_Fade();
                Main_character_bed.SetActive(true);
                Main_character_bed_Fade.SetActive(true);
            }
            if (charater == "Elphis_surprised")
            {
                UI_null();
                Main_charater_Fade();
                Main_character_surprised.SetActive(true);
                Main_character_surprised_Fade.SetActive(true);
            }
            if (charater == "pilia_happy")
            {
                UI_null();
                pilia_happy.SetActive(true);
            }
            if (charater == "pilia_Sad")
            {
                UI_null();
                pilia_Sad.SetActive(true);
            }
            if (charater == "pilia_Curiosity")
            {
                UI_null();
                pilia_Curiosity.SetActive(true);
            }
            if (charater == "pilia_Panic")
            {
                UI_null();
                pilia_Panic.SetActive(true);
            }
            if (charater == "pilia_Angry")
            {
                UI_null();
                pilia_Angry.SetActive(true);
            }
            if (charater == "pilia_awe")
            {
                UI_null();
                pilia_awe.SetActive(true);
            }
            if (charater == "pilia_nomal")
            {
                UI_null();
                pilia_nomal.SetActive(true);
            }
        }
    }
    public void UI_null()
    {
        Main_character_nomal.SetActive(false);
        Main_character_happy.SetActive(false);
        Main_character_bed.SetActive(false);
        Main_character_surprised.SetActive(false);
        pilia_happy.SetActive(false);
        pilia_Sad.SetActive(false);
        pilia_Curiosity.SetActive(false);
        pilia_Panic.SetActive(false);
        pilia_Angry.SetActive(false);
        pilia_awe.SetActive(false);
        pilia_nomal.SetActive(false);
        Color_Quiz.SetActive(false);
    }

    public void Main_charater_Fade()
    {
        Main_character_nomal_Fade.SetActive(false);
        Main_character_happy_Fade.SetActive(false);
        Main_character_surprised_Fade.SetActive(false);
        Main_character_bed_Fade.SetActive(false);
    }

}
