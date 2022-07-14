using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public static bool isJumped = false;
    public static bool isTalking = false;

    [HideInInspector] public bool Delay_Text;

    public Text text;           // ��ȭâ ����
    public Text CharacterName;  // �ι� �̸�

    public GameObject Text_Ui;            // ��ȭâ UI
    public GameObject text_Change;        // ��ä ����

    public GameObject character_UI;

    Character_UI gamemanager;

    void Update()
    {

    }
    public IEnumerator Stop_Dialogue() //���̾�α� ����
    {
        yield return null;
        Text_Ui.SetActive(false);
        CharacterName.text = "";
        text.text = "";
        gamemanager.All_UI_Stop();
        StopAllCoroutines();
        yield break;
    }

    public IEnumerator Dialogue_Inout(int Content, int Name, bool isnottalk) // ���̾�α� ��_�ƿ� ��ȭ ��ũ��Ʈ
    {
        if (!Delay_Text)
        {
            gamemanager.All_UI_Stop();
            List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");
            Text_Ui.SetActive(true);

            CharacterName.text = data_Dialog[Content]["Name"].ToString();
            StartCoroutine(Typing(text, data_Dialog[Name]["Content"].ToString()));

            gamemanager = character_UI.GetComponent<Character_UI>();

            if (!isnottalk)
            {
                gamemanager.All_UI_Stop();
                StartCoroutine(gamemanager.Text_UI_image(Content));
            }
            yield break;
        }

    }
    public IEnumerator Typing(Text typingText, string message)
    {
        for (int i = 0; i < message.Length; i++)
        {
            yield return null;
            typingText.text = message.Substring(0, i + 1);
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                yield break;
            }
        }

    }



    public IEnumerator Dialogue(int Content, int Name, int FinerContent) // ���̾�α� ��ȭ ��ũ��Ʈ
    {
        if (!Delay_Text)
        {
            List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");
            Text_Ui.SetActive(true);

            CharacterName.text = data_Dialog[Name]["Name"].ToString();
            StartCoroutine(Typing(text, data_Dialog[Content]["Content"].ToString()));

            gamemanager = character_UI.GetComponent<Character_UI>();
            StartCoroutine(gamemanager.Text_UI_image(Content));

            while (true)
            {
                yield return null;

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    Content++;
                    Name++;

                    CharacterName.text = data_Dialog[Name]["Name"].ToString();
                    StartCoroutine(Typing(text, data_Dialog[Content]["Content"].ToString()));

                    gamemanager = character_UI.GetComponent<Character_UI>();
                    StartCoroutine(gamemanager.Text_UI_image(Content));

                    if (Content == FinerContent + 1 || Input.GetKeyDown(KeyCode.Space) && Input.GetMouseButtonDown(0))
                    {
                        gamemanager.All_UI_Stop();
                        GameManager.isTalking = false;
                        Text_Ui.SetActive(false);
                        yield break;
                    }
                }
            }
        }

    }
}

