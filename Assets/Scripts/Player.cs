using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float movespeed = 5;

    private Vector3 _playerInput;

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void PlayerInput()
    {
        _playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void Move()
    {
        _rb.MovePosition(transform.position + transform.forward * _playerInput.normalized.magnitude * movespeed * Time.deltaTime);
    }
}
