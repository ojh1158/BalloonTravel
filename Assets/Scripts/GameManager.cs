using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool isJumped = false;
    public static bool isTalking = false;

    public Text text; // 대화창 내용
    public Text CharacterName; // 인물 이름

    public GameObject Text_Ui; // 대화창 UI

    void Update()
    {

    }

    public IEnumerator Dialogue(int Content, int Name, int FinerContent) // 다이얼로그 대화 스크립트
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");
        //Debug.Log("코루틴 시작 부분");
        Text_Ui.SetActive(true);

        CharacterName.text = data_Dialog[Content]["Name"].ToString();
        StartCoroutine(Typing(text, data_Dialog[Name]["Content"].ToString(), 0.01f));

        while (true)
        {
            yield return null;
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
            {
                Content++;
                Name++;

                CharacterName.text = data_Dialog[Content]["Name"].ToString();
                StartCoroutine(Typing(text, data_Dialog[Name]["Content"].ToString(), 0.01f));

                if (Content == FinerContent +1 && Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
                {
                    Text_Ui.SetActive(false);
                    GameManager.isTalking = false;
                    yield break;
                }
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
        IEnumerator Typing(Text typingText, string message, float speed)
        {
            //Debug.Log("타이핑 코루틴");
            for (int i = 0; i < message.Length; i++)
            {
                typingText.text = message.Substring(0, i + 1);
                yield return new WaitForSeconds(speed);
            }
        }

    }
