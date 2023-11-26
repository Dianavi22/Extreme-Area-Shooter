using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField] private GameObject _cubes;
    [SerializeField] private GameObject _particules;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SetActiveCubes", 0.65f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetActiveCubes()
    {
        _cubes.SetActive(true);
        _particules.SetActive(false);
    }
}
