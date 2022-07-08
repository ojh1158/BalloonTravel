using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public static bool isJumped = false;
    public static bool isTalking = false;

    public Text text; // ��ȭâ ����
    public Text CharacterName; // �ι� �̸�

    public GameObject Text_Ui; // ��ȭâ UI
    public GameObject text_Change; // ��ä ����

    void Update()
    {

    }

    public IEnumerator Stop_Dialogue() //���̾�α� ����
    {
        yield return null;
        Text_Ui.SetActive(false);
        StopAllCoroutines();
        yield break;
    }

    public IEnumerator Dialogue_Inout(int Content, int Name) // ���̾�α� ��_�ƿ� ��ȭ ��ũ��Ʈ
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");
        Text_Ui.SetActive(true);

        CharacterName.text = data_Dialog[Content]["Name"].ToString();
        StartCoroutine(Typing(text, data_Dialog[Name]["Content"].ToString()));
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



    public IEnumerator Dialogue(int Content, int Name, int FinerContent, bool roopTalking) // ���̾�α� ��ȭ ��ũ��Ʈ
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");
        Text_Ui.SetActive(true);

        CharacterName.text = data_Dialog[Name]["Name"].ToString();
        StartCoroutine(Typing(text, data_Dialog[Content]["Content"].ToString()));

        while (true)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
            {
                Content++;
                Name++;

                CharacterName.text = data_Dialog[Name]["Name"].ToString();
                StartCoroutine(Typing(text, data_Dialog[Content]["Content"].ToString()));

                if (Content == FinerContent + 1 || Input.GetKeyDown(KeyCode.Z) && Input.GetMouseButtonDown(0))
                {
                    Text_Ui.SetActive(false);
                    GameManager.isTalking = false;
                    yield break;
                }
            }
        }
    }

}
