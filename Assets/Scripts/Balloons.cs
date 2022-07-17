using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloons : MonoBehaviour
{
    Vector3 destination;
    Vector3 speed = Vector3.zero;

    public GameObject BallonRope;

    private float rand1;
    private float rand2;


    public void Start()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);        // ������ ���� ����

        rand1 = Random.Range(700f, 1300f);  // ���� ��(ǳ���� �ö󰡴� ����)
        rand2 = Random.Range(0.5f, 2.0f);   // ���� �ӵ�(���� �������� ����� �ӵ�)
    }

    public void Update()
    {
        if (GameManager.onBalloon)
            destination = new Vector3(transform.position.x + Random.Range(10f, -10f), transform.position.y + 40f, transform.position.z + Random.Range(10f, -10f));  // ǳ���� �ö󰡸鼭 �¿�� �����ϰ� �̵�

        if (GameManager.onBalloon == false)
        {
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref speed, rand1 * Time.deltaTime);
            BallonRope.transform.rotation = Quaternion.Slerp(BallonRope.transform.rotation, Quaternion.Euler(-90, 0, 0), rand2 * Time.deltaTime);
        }
    }
}
