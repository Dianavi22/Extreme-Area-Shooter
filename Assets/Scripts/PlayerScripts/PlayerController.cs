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

    private void Start()
    {
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        transform.Translate(movementDirection * _speed * Time.deltaTime, Space.World);
        var mousePos = Input.mousePosition;
        var wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.transform.position.y));

        transform.LookAt(wantedPos);

    }



   
}


