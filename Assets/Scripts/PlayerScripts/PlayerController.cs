using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float _speed = 10;
    [SerializeField]  Vector3 ScreenMouse;
    [SerializeField]  Vector3 WorldMouse;
    [SerializeField] Camera MainCamera;
    [SerializeField] Rigidbody _rb;


    private Vector3 movementDirection;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        _rb.detectCollisions = true;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movementDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
        Debug.Log("movementDirection : " + movementDirection);
        var mousePos = Input.mousePosition;
        var wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.transform.position.y));

        transform.LookAt(wantedPos);

    }

    private void FixedUpdate()
    {
        //_rb.position += movementDirection * _speed * Time.deltaTime;
        transform.Translate(movementDirection * _speed * Time.deltaTime, Space.World);
    }




}


