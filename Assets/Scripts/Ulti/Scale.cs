using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public static Scale scale;
    private bool _statusLaser = false;
    [SerializeField] GameObject _laserGO;

    private bool _isCurrentUlti = false;

    private void Start()
    {
        _laserGO.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            LaunchUlti();
        }

        if (!_isCurrentUlti)
        {
            StopUlti();
        }
    }

    public void LaunchUlti()
    {
        _isCurrentUlti = true;

        _laserGO.SetActive(true);
        StartCoroutine("LaserStart");
        _statusLaser = true;
        StartCoroutine("CurrentUlti");
        
    }

    public void StopUlti()
    {
        StartCoroutine("LaserStop");
        _statusLaser = false;
        _laserGO.SetActive(false);
    }
    IEnumerator LaserStart()
    {
            StartCoroutine("Extend", 0.01F);
            yield return new WaitForSeconds(1);
            StopCoroutine("Extend");
    }

    IEnumerator LaserStop()
    {
        StartCoroutine("Retract", 2.0F);
        yield return new WaitForSeconds(1f);
        StopCoroutine("Retract");
    }


    IEnumerator Extend(float someParameter)
    {
        while (true)
        {
            transform.localScale += new Vector3(0, 0.3f, 0);
            yield return null;
        }
    }

    IEnumerator Retract(float someParameter)
    {
        //while (true)
        //{
        //    transform.localScale -= new Vector3(0, 0.1f, 0);
        //    yield return null;
        //}
        transform.localScale = new Vector3(1,1,1);
        yield return null;
    }

    IEnumerator CurrentUlti()
    {
        yield return new WaitForSeconds(0.5f);
        _isCurrentUlti = false;
    }
}
