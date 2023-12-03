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

    [SerializeField] private bool _isWalled;
    private Vector3 movementDirection;

    public bool inMotion;

    [SerializeField] ParticleSystem _dashParticleSystem;

    [SerializeField] private ParticleSystem _takeItemParticules;
    private AudioSource _audioSource;
    [SerializeField] AudioClip _takeItemSound;
    [SerializeField] AudioClip _dash;


    private void Start()
    {
        _speed = baseSpeed;
        _audioSource = GetComponent<AudioSource>();

        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rb.detectCollisions = true;
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (verticalInput != 0 || horizontalInput != 0)
        {
            movementDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
            transform.Translate(movementDirection * _speed * Time.deltaTime, Space.World);
        }
        
        var mousePos = Input.mousePosition;
        var wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.transform.position.y));

        transform.LookAt(wantedPos);
        
        #region Dash
        if (Input.GetKeyDown(KeyCode.Space) && !_isWalled)
        {
            if(dashCoolCounter <= 0 && dashCounter <= 0)
            {
                _speed = _dashSpeed;
                dashCounter = dashLenght;
                _dashParticleSystem.Play();
                _audioSource.PlayOneShot(_dash, 0.03f);

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

        #endregion

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            _speed = baseSpeed;
            _isWalled = true;
        }

        if (collision.collider.CompareTag("Item"))
        {
            if (!_gameManager.isPhase2) { _audioSource.PlayOneShot(_takeItemSound, 0.07f); }
            else { _audioSource.PlayOneShot(_takeItemSound, 0.65f); }
            _takeItemParticules.Play();
            _isWalled = false;

        }

        if (collision.collider.CompareTag("Enemy"))
        {
            _isWalled = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            _isWalled = false;
        }
    
      
    }

}


