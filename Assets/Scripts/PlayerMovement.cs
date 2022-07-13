using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    [Header("Player Settings")]
    public Camera PlayerCamera;
    public float speed = 5f;
    public float onBalloonSpeed = 0.5f;
    public float rotateSpeed = 10f;
    public float deployHeight = 40f;
    public Transform startPoint;

    private Vector3 vel;

    [HideInInspector] public Vector3 rightMovement;
    [HideInInspector] public Vector3 upMovement;
    [Space(10)]

    Vector3 horizontalMovement;
    Vector3 verticalMovement;

    [Header("Jump Setting")]
    public float jumpForce;
    private bool readyToJump;
    public float jumpWaitTime = 2f;
    [Space(10)]

    public Rigidbody rb;

    [Header("Falling Setting")]
    public float fallSpeed = 5f;
    [Space(10)]

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask groundMask;
    bool isGrounded;
    [Space(10)]

    [Header("Balloon")]
    public GameObject Balloons;
    private GameObject clone;
    public Transform BalloonAttachPosition;
    //[Space(10)]

    //[Header("AirBalloon")]
    //public Transform AirBalloonTarget;
    //RaycastHit hit;     // ���ⱸ��


    private void Start()        // ������ �� ������ ��ġ�� �̵�
    {
        transform.position = startPoint.position;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        readyToJump = true;
    }

    void Update()
    {
        // ����
        if (Input.GetKeyDown(KeyCode.Space) && readyToJump && isGrounded && GameManager.isTalking == false)
        {
            readyToJump = false;
            StartCoroutine(JumpDelay());
            Jump();
        }

        // ���ⱸ ž��
        //if(Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, 10))
        //{
        //    Debug.Log(hit.collider.name);
        //    //Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * hit.distance, Color.red);

        //    if (Input.GetKey(KeyCode.E) && hit.collider.name == "AirBalloon")
        //    {
        //        transform.position = AirBalloonTarget.position;
        //    }
        //}
    }

    void FixedUpdate()
    {
        // �� ���� �ִ��� Ȯ��
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundMask);
        //Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        GroundCheck();

        // ī�޶� �������� �����¿� ������
        horizontalMovement = Camera.main.transform.forward;
        horizontalMovement.y = 0;
        horizontalMovement = Vector3.Normalize(horizontalMovement);
        verticalMovement = Quaternion.Euler(new Vector3(0, 90, 0)) * horizontalMovement;

        // �ִϸ��̼� ���� ������Ʈ
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) && GameManager.isTalking == false)
        {
            Move();
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if (!isGrounded)
        {
            GameManager.isGround = false;
            animator.SetBool("isGround", false);
        }
        else
        {
            GameManager.isJumped = false;
            GameManager.isGround = true;

            animator.SetBool("isJumping", false);
            animator.SetBool("isGround", true);
        }

        // �� �Ʒ��� �������� ��
        if (transform.position.y < -10)
        {
            // �������� ��ġ(�� ��ġ�� ���� ���� ��Ҵ� �޶��� �� ����) 
            Vector3 deployPoint = GameObject.FindWithTag("Island").transform.position;

            transform.position = new Vector3(deployPoint.x, deployHeight, deployPoint.z);

            animator.SetBool("isHanging", true);

            clone = Instantiate(Balloons, BalloonAttachPosition.transform.position, Balloons.transform.rotation * Quaternion.Euler(Balloons.transform.rotation.x, Balloons.transform.rotation.y, Random.Range(-90f, 90f)));
            clone.transform.SetParent(BalloonAttachPosition.transform);

            // ���ϼӵ�
            if (GameManager.onAir == true)
            {
                rb.drag = fallSpeed;
            }
        }
    }

    void GroundCheck()
    {
        RaycastHit check;

        if (!Physics.Raycast(transform.position, Vector3.down, out check, 5f))
        {
            GameManager.onAir = true;
            animator.SetBool("isFalling", true);
            animator.SetFloat("FallBlend", 1f);
        }
        else
        {
            GameManager.onAir = false;

            if (GameManager.isGround == true)
            {
                rb.drag = 0f;

                animator.SetBool("isFalling", false);
                animator.SetBool("isHanging", false);

                if (clone != null)
                {
                    StartCoroutine(DestroyBalloon());
                }
            }
            animator.SetFloat("FallBlend", 0f);
        }
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        rightMovement = verticalMovement * speed * Time.deltaTime * Input.GetAxis("Horizontal");
        upMovement = horizontalMovement * speed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;

        direction = Camera.main.transform.TransformDirection(direction);
        direction.y = 0;

        if (rb.drag != 0)
        {
            rb.MovePosition(rb.position + direction * onBalloonSpeed * Time.deltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
        }

        // ���߿� ���� �� �̵��ӵ� ����

        //transform.position += upMovement;
        //transform.position += rightMovement;

    }

    void Jump()
    {
        GameManager.isJumped = true;
        animator.SetBool("isJumping", true);
        animator.SetBool("isGround", false);

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    IEnumerator JumpDelay()
    {
        yield return new WaitForSeconds(jumpWaitTime);

        readyToJump = true;
    }

    IEnumerator DestroyBalloon()
    {
        clone.transform.parent = null;
        Destroy(clone, 5f);

        yield return null;
    }
}
