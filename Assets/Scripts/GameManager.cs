using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isTalking = false;   // NPC�� ��ȭ������ Ȯ���� �� ���
    public static bool isGround = true;     
    public static bool onAir = false;       // �� ������ �������� ����, ���߿� �ִ��� Ȯ��(isGround, CoundCheck���� �� �� �Ÿ��� ����)
    public static bool onBalloon = false;   // ǳ���� �Ŵ޷� ���� ��
    public static bool doJumpMap = false;

    // ��� ���� �ִ��� 
    public static Island state;

    public enum Island
    {
        Air,        // default
        FirstWorld,
        Puzzle_Maze,
        Puzzle_Jump,
        Story,
        Ending
    }


    private void Start()
    {

    }

    void Update()
    {
        //Debug.Log(state);
        //Debug.Log(onBalloon);
    }
}
