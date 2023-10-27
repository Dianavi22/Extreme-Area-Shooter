using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float _speed;
    public float baseSpeed = 10;
    [SerializeField]  Vector3 ScreenMouse;
    [SerializeField]  Vector3 WorldMouse;
    [SerializeField] Camera MainCamera;
    [SerializeField] Rigidbody _rb;
    [SerializeField] GameManager _gameManager;
    [SerializeField] Item _item;

    private float dashLenght = .2f, dashCooldown = 0.4f;
    [SerializeField] private float _dashSpeed = 18; 
    private float dashCounter;
    private float dashCoolCounter;

    private bool _isWalled;
    private Vector3 movementDirection;
    private void Start()
    {
        _speed = baseSpeed;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        _rb.detectCollisions = true;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movementDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        var mousePos = Input.mousePosition;
        var wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.transform.position.y));

        transform.LookAt(wantedPos);

        if (Input.GetKeyDown(KeyCode.Space) && !_isWalled)
        {
            if(dashCoolCounter <= 0 && dashCounter <= 0)
            {
                _speed = _dashSpeed;
                dashCounter = dashLenght;
            }
        }
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if(dashCounter <= 0)
            {
                _speed = baseSpeed;
                dashCoolCounter = dashCooldown;
            }
        }
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }



    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            _speed = baseSpeed;
            _isWalled = true;
        }

       
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            _isWalled = false;
        }
    }
    private void FixedUpdate()
    {
        //_rb.position += movementDirection * _speed * Time.deltaTime;
        transform.Translate(movementDirection * _speed * Time.deltaTime, Space.World);
    }




}


