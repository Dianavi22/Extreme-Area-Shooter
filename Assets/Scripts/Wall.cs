using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

   
    [SerializeField]
    private Material _redShaking;

    [SerializeField]
    private Material _glowBlue;

    [SerializeField]
    private Material _redGameOver;

    [SerializeField]
    private CameraController _cameraController;

    [SerializeField]
    private MeshRenderer _meshRenderer;

    private PlayerHealth _playerHealth;

    private void Awake()
    {
        _cameraController.GetComponent<CameraController>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _playerHealth = FindObjectOfType<Player>().GetComponent<PlayerHealth>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (_cameraController.shakeshake == true && _playerHealth.isAlive)
        {
            _meshRenderer.material = _redShaking;
            Invoke("ChangeColorWall",1f);
        }

        if (!_playerHealth.isAlive)
        {
            _meshRenderer.material = _redGameOver;

        }


    }

    private void ChangeColorWall()
    {
        _meshRenderer.material = _glowBlue;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("ENTER");
        }
    }
}
