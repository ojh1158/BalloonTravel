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
    int clickCount = 0;//클릭횟수 카운터 

    public TextAsset txt;
    string[,] Sentence;
    public int lineSize;
    public int rowSize;

    void Start()
    {
        // 엔터단위와 탬으로 나눠서 배열의 크기 조정
        string currentText = txt.text.Substring(0, txt.text.Length - 1);
        string[] line = currentText.Split('\n');
        lineSize = line.Length;
        rowSize = line[0].Split('\t').Length;
        Sentence = new string[lineSize, rowSize];

        // 한 줄에서 탭으로 나눔
        for (int i = 0; i < lineSize; i++)
        {
            string[] row = line[i].Split("\t");
            for (int j = 0; j < rowSize; j++) Sentence[i, j] = row[j];
        }
    }

    public void TalkStart()
    {
        Text_Ui.SetActive(true);
        clickCount = 0;
        text.text = Sentence[0, 1];
        CharacterName.text = Sentence[0, 0];
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (clickCount == 0)
            {
                text.text = Sentence[1, 1];
                CharacterName.text = Sentence[1, 0];
                clickCount++;
            }

            else if (clickCount == 1)
            {
                text.text = Sentence[2, 1];
                CharacterName.text = Sentence[2, 0];
                clickCount++;
            }

            else if (clickCount == 2)
            {
                text.text = Sentence[3, 1];
                CharacterName.text = Sentence[3, 0];
                clickCount++;

            }
            else if (clickCount == 3)
            {
                text.text = Sentence[4, 1];
                CharacterName.text = Sentence[4, 0];
                clickCount++;
            }
            else if (clickCount == 4)
            {
                text.text = Sentence[5, 1];
                CharacterName.text = Sentence[5, 0];
                Text_Ui.SetActive(false);
                clickCount = 0;
            }
        }
    }
}
