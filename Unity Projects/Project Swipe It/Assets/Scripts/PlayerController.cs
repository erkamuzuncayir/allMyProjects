using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum SIDE { Left, Mid, Right }

public class PlayerController : MonoBehaviour
{
    public static PlayerController playerControllerInstance;
    public Animator playerAnimator;
    public SIDE m_Side = SIDE.Mid;
    private bool swipeLeft, swipeRight, swipeUp;
    private float xValue = 2;
    [SerializeField] private float strafeSpeed = 1;
    [SerializeField] private float jumpSpeed;
    private Vector3 startPosition = Vector3.zero;
    private Vector3 goalPosition = Vector3.zero;

    // Start is called before the first frame update
    void Awake()
    {
        playerControllerInstance = this;
        playerAnimator = GetComponent<Animator>();
        startPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Input settings
        swipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        swipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        swipeUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);

        // Right and left movement
        if (swipeLeft)
        {
            if (m_Side == SIDE.Mid)
            {
                playerAnimator.Play("strafeLeft");
                goalPosition.x = -xValue;
                m_Side = SIDE.Left;
            }
            else if (m_Side == SIDE.Right)
            {
                playerAnimator.Play("strafeLeft");
                goalPosition.x = 0;
                m_Side = SIDE.Mid;
            }
        }
        if (swipeRight)
        {
            if (m_Side == SIDE.Mid)
            {
                playerAnimator.Play("strafeRight");
                goalPosition.x = xValue;
                m_Side = SIDE.Right;
            }
            else if (m_Side == SIDE.Left)
            {
                playerAnimator.Play("strafeRight");
                goalPosition.x = 0;
                m_Side = SIDE.Mid;
            }
        }
        // Jump movement
        if (swipeUp && (startPosition.y < 0.5f))
        {
            playerAnimator.Play("jump");
            goalPosition.y = 5;
        }
        if (startPosition.y > 3)
        {
            goalPosition.y = 0;
        }
        // Make character move
        float lerpValue = strafeSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(startPosition, goalPosition, lerpValue);
        startPosition = gameObject.transform.position;
    }
    public void DeathMove(bool isPlayerDead)
    {
        if(isPlayerDead)
        {
            playerAnimator.Play("death");
        }
    }
}
