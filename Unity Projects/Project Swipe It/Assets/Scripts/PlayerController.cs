using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum SIDE { Left, Mid, Right }

public class PlayerController : MonoBehaviour
{
    private CharacterController playerController;
    private Animator m_Animator;
    public SIDE m_Side = SIDE.Mid;
    private bool swipeLeft, swipeRight, swipeUp;
    private float xValue = 2;
    private float strafeSpeed = 1;
    [SerializeField] private float jumpSpeed;
    private Vector3 startPosition = Vector3.zero;
    private Vector3 goalPosition = Vector3.zero;




    public float jumpForce = 20f;
    public float gravity = -9.81f;
    public float gravityMultiplier = 1f;
    float velocity;
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        m_Animator = GetComponent<Animator>();
        startPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = gravity * Time.deltaTime;
        float lerpValue = strafeSpeed * Time.deltaTime;


        // Input settings
        swipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        swipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        swipeUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);

        // Right and left movement
        if (swipeLeft)
        {
            if (m_Side == SIDE.Mid)
            {
                m_Animator.Play("strafeLeft");
                goalPosition.x = -xValue;
                m_Side = SIDE.Left;
            }
            else if (m_Side == SIDE.Right)
            {
                m_Animator.Play("strafeLeft");
                goalPosition.x = 0;
                m_Side = SIDE.Mid;
            }
        }
        if (swipeRight)
        {
            if (m_Side == SIDE.Mid)
            {
                m_Animator.Play("strafeRight");
                goalPosition.x = xValue;
                m_Side = SIDE.Right;
            }
            else if (m_Side == SIDE.Left)
            {
                m_Animator.Play("strafeRight");
                goalPosition.x = 0;
                m_Side = SIDE.Mid;
            }
        }
        // Jump movement

            if (swipeUp)
            {
            goalPosition.y = 500;
            }

            transform.position = Vector3.Lerp(startPosition, goalPosition, lerpValue);
            startPosition = gameObject.transform.position;
            if(goalPosition.y > 0)
        {
            goalPosition.y -= goalPosition.y - 0.1f;
        }
    }
}
