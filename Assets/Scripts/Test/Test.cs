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
            StartCoroutine(test());
            Text_Ui.SetActive(true);
        }
    }

     IEnumerator test()
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("Dialog");
        Debug.Log("코루틴 시작 부분");
       
        text.text = data_Dialog[Dialog_Content]["Content"].ToString();
        CharacterName.text = data_Dialog[Dialog_Name]["Name"].ToString();

        Dialog_Content = 29;
        Dialog_Name = 29;
        StartCoroutine(Typing(text, m_Message, 0.2f));

        while (true)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.Z))
            {
                text.text = data_Dialog[Dialog_Content]["Content"].ToString();
                CharacterName.text = data_Dialog[Dialog_Name]["Name"].ToString();

                Dialog_Content++;
                Dialog_Name++;
                StartCoroutine(Typing(text,m_Message, 0.2f));
                if (Dialog_Content == 38)
                {
                    Dialog_Content = 0;
                    Dialog_Name = 0;

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
