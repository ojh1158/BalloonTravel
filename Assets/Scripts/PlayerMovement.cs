using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    public float speed = 5f;
    public float rotateSpeed = 10f;

    Vector3 horizontalMovement;
    Vector3 verticalMovement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalMovement = Camera.main.transform.forward;
        horizontalMovement.y = 0;
        horizontalMovement = Vector3.Normalize(horizontalMovement);
        verticalMovement = Quaternion.Euler(new Vector3(0, 90, 0)) * horizontalMovement;

        if (GameManager.isMoving == true)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    void FixedUpdate()
    {
        if (Input.anyKey)
        {
            Move();
        }
        else
        {
            GameManager.isMoving = false;
        }
    }

    void Move()
    {
        GameManager.isMoving = true;

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Vector3 rightMovement = verticalMovement * speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = horizontalMovement * speed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }
}