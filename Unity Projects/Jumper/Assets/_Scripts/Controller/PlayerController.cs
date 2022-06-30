using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    private Rigidbody _playerRigidbody;
    public GameObject heightSliderUI;
    public GameObject dashSliderUI;
    private Slider _heightRateSlider;
    private Slider _dashRateSlider;
    private Vector3 _playerMovementInput;
    [SerializeField] private float speed, valueModifier, jumpHeight, dash;
    [SerializeField] private bool heightCounter, jumpMove;
    public bool isGrounded;

    private void Start()
    {
        Instance = this;
        _playerRigidbody = GetComponent<Rigidbody>();
        _heightRateSlider = heightSliderUI.GetComponent<Slider>();
        _dashRateSlider = dashSliderUI.GetComponent<Slider>();
    }

    private void Update()
    {
        // Input
        _playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, 1f);
        // Movement
        valueModifier = Time.deltaTime * 20f;
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            heightCounter = false;
            jumpMove = true;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            heightCounter = true;
        }

        if (heightCounter)
        {
            if (jumpHeight > 40)
            {
                jumpHeight = 0;
            }

            if (jumpHeight <= 40)
            {
                jumpHeight += valueModifier;
            }

            dash = 40 - jumpHeight;
            /*
            dash = Mathf.PingPong(Time.time * 30f, 20);
            */
            _heightRateSlider.value = jumpHeight;
            _dashRateSlider.value = dash;
        }

        transform.Translate(Vector3.forward * (Time.deltaTime * 20f));

        MovePlayer();

        // UI Sliders
        /*_heightRateSlider.value = jumpHeight;
        _dashRateSlider.value = Mathf.Abs(40 - jumpHeight);*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        // Player death when hit the front side of platforms.
        Vector3 normal = collision.contacts[0].normal;
        if (normal.z < 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Game");
        }
    }

    private void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(_playerMovementInput) * speed;
        var playerVelocity = _playerRigidbody.velocity;
        playerVelocity = new Vector3(moveVector.x, playerVelocity.y, playerVelocity.z);
        _playerRigidbody.velocity = playerVelocity;
        if (!isGrounded) return;
        if (!jumpMove) return;
        _playerRigidbody.velocity = new Vector3(moveVector.x, jumpHeight, dash);
        // Getting reset values
        jumpHeight = 0;
        dash = 0;
        jumpMove = false;
        isGrounded = false;
    }
    /*public static PlayerController Instance;
    private Side _whichSide = Side.Mid;
    private bool _swipeLeft, _swipeRight;
    private bool _swipeUp, _heightCounter, _isGrounded;
    private const float XValue = 2;
    private const float JumpSpeed = 20f;
    private const float HeightMultiplier = 20f;
    [SerializeField] private float desiredJumpHeight, checker, gameSpeed = 10;
    [Range(0f, 20f)]
    [SerializeField] private float jumpHeight;
    private Vector3 _startPosition = new Vector3(0, 1, 0);
    private Vector3 _goalPosition = new Vector3(0, 1, 0);

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }
    private void Awake()
    {
        Instance = this;
        _startPosition = gameObject.transform.position;
        _startPosition.y = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            if (checker == desiredJumpHeight)
            {
                desiredJumpHeight = 0;
            }

            _isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }

    private void Update()
    {
        // Input settings
        _swipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        _swipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            _heightCounter = false;
            _swipeUp = true;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            _heightCounter = true;
        }

        // Right and left movement
        if (_swipeLeft)
        {
            switch (_whichSide)
            {
                case Side.Mid:
                    _goalPosition.x = -XValue;
                    _whichSide = Side.Left;
                    break;
                case Side.Right:
                    _goalPosition.x = 0;
                    _whichSide = Side.Mid;
                    break;
            }
        }

        if (_swipeRight)
        {
            switch (_whichSide)
            {
                case Side.Mid:
                    _goalPosition.x = XValue;
                    _whichSide = Side.Right;
                    break;
                case Side.Left:
                    _goalPosition.x = 0;
                    _whichSide = Side.Mid;
                    break;
            }
        }

        // Jump movement
        if (_heightCounter && jumpHeight < 20)
        {
            jumpHeight += (Time.deltaTime * HeightMultiplier);
            
        }

        if (_swipeUp)
        {
            desiredJumpHeight = jumpHeight;
            jumpHeight = 0;
            _swipeUp = false;
        }

        switch (_isGrounded)
        {
            case true:
                checker = desiredJumpHeight;
                _goalPosition.y = desiredJumpHeight;
                break;
            case false when Math.Abs(_startPosition.y - _goalPosition.y) < 1:
                _goalPosition.y = 0;
                break;
        }
        
        // Dash movement
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerRigidbody.AddForce(transform.forward * 10f, ForceMode.Force);
        }
        
        
        
        // Make character move
        _goalPosition.z += Time.deltaTime * gameSpeed;
        var deltaTime = Time.deltaTime;
        transform.position = Vector3.MoveTowards(_startPosition, _goalPosition, deltaTime * JumpSpeed);
        _startPosition = gameObject.transform.position;
    }*/
}