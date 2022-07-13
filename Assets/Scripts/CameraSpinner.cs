using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpinner : MonoBehaviour
{
    public GameObject Player;
    public Transform target;

    [Header("Camera Settings")]
    public int RotateAngle = 45;
    public float MinimumFollowAmount = -10;
    public float MaximumFollowAmount = 30;


    void Update()
    {
        Vector3 PlayerPosition = Player.transform.position;

        transform.position = target.position.x * Vector3.right + target.position.z * Vector3.forward;


        // ī�޶� ���� ���� ���� ������ �̵��� �� �ֵ���(�÷��̾ �������� �ϴÿ��� �������� ����� �����ֱ� ����)
        if (target.position.y > MaximumFollowAmount)
        {
            transform.position = new Vector3(target.position.x, 30f, target.position.z);
        }

        if (target.position.y < -10)
        {
            transform.position = new Vector3(target.position.x, 30, target.position.z);
        }

        if (target.position.y >= MinimumFollowAmount && target.position.y <= MaximumFollowAmount)       // ĳ���Ͱ� ������ �� ���� �κб����� ���󰡰� ���� -> �������� ���� �Ű� �ϴÿ��� (ǳ���� Ÿ��) �ٽ� �������� ǥ���� �ϱ� ����
        {
            transform.position = target.position.y * Vector3.up + target.position.x * Vector3.right + target.position.z * Vector3.forward;
            transform.LookAt(PlayerPosition);
        }

        // ī�޶� ȸ��
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.RotateAround(PlayerPosition, Vector3.up, -RotateAngle);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.RotateAround(PlayerPosition, Vector3.up, RotateAngle);
        }
    }
}