using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum SIDE { Left, Mid, Right }

public class PlayerController : MonoBehaviour
{
    public SIDE m_Side = SIDE.Mid;
    private float newXPos = 0f;
    [HideInInspector]
    public bool swipeLeft, swipeRight, swipeUp, swipeDown;
    public float xValue;
    private CharacterController playerController;
    private Animator m_Animator;
    private float x;
    public float strafeSpeed;
    public float jumpPower = 0.015f;
    private float y;
    [SerializeField]
    private float gravity = 0.002f;
    [SerializeField]
    private float runSpeed = 5.0f;
    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isGrounded)
        {
            swipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
            swipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
            swipeUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
            if (swipeLeft)
            {
                if (m_Side == SIDE.Mid)
                {
                    m_Animator.Play("strafeLeft");

                    newXPos = -xValue;
                    m_Side = SIDE.Left;
                }
                else if (m_Side == SIDE.Right)
                {
                    m_Animator.Play("strafeLeft");

                    newXPos = 0;
                    m_Side = SIDE.Mid;
                }
            }
            if (swipeRight)
            {
                if (m_Side == SIDE.Mid)
                {
                    m_Animator.Play("strafeRight");

                    newXPos = xValue;
                    m_Side = SIDE.Right;
                }
                else if (m_Side == SIDE.Left)
                {
                    m_Animator.Play("strafeRight");

                    newXPos = 0;
                    m_Side = SIDE.Mid;
                }
            }
            x = Mathf.Lerp(x, newXPos, Time.deltaTime * strafeSpeed);
            moveDirection = new Vector3(x - transform.position.x, y * Time.deltaTime, runSpeed * Time.deltaTime);
            if (swipeUp)
            {
                moveDirection.y = jumpPower;
                m_Animator.Play("jump");
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        playerController.Move(moveDirection);

        //float horizontalInput = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        //this.transform.Translate(horizontalInput, 0, runSpeed * Time.deltaTime);
    }
    //public void Jump()
    //{
    //    if (swipeUp)
    //    {
    //        y = jumpPower;
    //        m_Animator.Play("jump");
    //    }
    //    else
    //    {
    //        y -= jumpPower * 2 * Time.deltaTime;
    //    }
    //}
}
