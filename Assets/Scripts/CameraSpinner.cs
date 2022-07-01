using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpinner : MonoBehaviour
{
    public GameObject Player;
    public Transform target;
    public Vector3 offset;

    public Vector3 test_con;
    public float IN =0;
    public int RotateAngle = 45;

    void Update()
    {
        transform.position = target.position + offset;
        //transform.position = new Vector3(target.position.x + 1.0f, target.position.y + 1.0f, target.position.z + 1.0f);
        //test_con = target.position;

        Vector3 PlayerPosition = Player.transform.position;

        if(Input.GetKeyDown(KeyCode.Q))
        {
          transform.RotateAround(PlayerPosition,Vector3.up,RotateAngle);
        }

        else if(Input.GetKeyDown(KeyCode.E))
        {
          transform.RotateAround(PlayerPosition,Vector3.up,-RotateAngle);
        }

        transform.LookAt(PlayerPosition);
    }
}