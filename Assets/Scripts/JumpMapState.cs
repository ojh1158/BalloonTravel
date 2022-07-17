using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMapState : MonoBehaviour
{
    Collider _collider;

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        GameManager.doJumpMap = true;
    }

    private void OnTriggerExit(Collider other)
    {
        GameManager.doJumpMap = false;
        _collider.isTrigger = false;    // �������� ���� �� �������� �� ������ �ϱ� ����
    }
}
