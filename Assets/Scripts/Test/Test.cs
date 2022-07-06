using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Text text;
    public Text CharacterName;

    public GameObject Text_Ui;

    public string m_Message;

    int Dialog_Content;
    int Dialog_Name;

    public void OnTriggerEnter(Collider other)
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");

        if (other.tag == "Player")
        {
            Dialog_Content = 29;
            Dialog_Name = 29;

            StartCoroutine(test(Dialog_Content, Dialog_Name));
            //Text_Ui.SetActive(true);
        }
    }

    IEnumerator test(int Content, int Name)
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");
        Debug.Log("코루틴 시작 부분");
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

                yield return new WaitForSeconds(0.2f);

                if (Content == 38)
                {
                    Content = 0;
                    Name = 0;

                    Text_Ui.SetActive(false);

                    GameManager.isTalking = false;
                    yield break;
                }
            }

        }

    }



    IEnumerator Typing(Text typingText, string message, float speed)
    {
        Debug.Log("타이핑 코루틴");
        for (int i = 0; i < message.Length; i++)
        {
            typingText.text = message.Substring(0, i + 1);
            yield return new WaitForSeconds(speed);
        }
    }

}
