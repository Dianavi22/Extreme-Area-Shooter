using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;
    void Start()
    {
        _playerController = FindObjectOfType<Player>().GetComponent<PlayerController>();

    }

    void Update()
    {
       // _playerController.baseSpeed = 15;
    }
}
