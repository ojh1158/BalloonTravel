using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    Vector3 horizontalMovement;
    Vector3 verticalMovement;

    //void Start()
    //{
    //    horizontalMovement = Camera.main.transform.forward;
    //    horizontalMovement.y = 0;
    //    horizontalMovement = Vector3.Normalize(horizontalMovement);
    //    verticalMovement = Quaternion.Euler(new Vector3(0, 90, 0)) * horizontalMovement;
    //}

    void Update()
    {
        horizontalMovement = Camera.main.transform.forward;
        horizontalMovement.y = 0;
        horizontalMovement = Vector3.Normalize(horizontalMovement);
        verticalMovement = Quaternion.Euler(new Vector3(0, 90, 0)) * horizontalMovement;
    }

    void FixedUpdate()
    {
        if(Input.anyKey)
            Move();
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));     // 작동 안하는 중
        Vector3 rightMovement = verticalMovement * speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = horizontalMovement * speed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }

}
