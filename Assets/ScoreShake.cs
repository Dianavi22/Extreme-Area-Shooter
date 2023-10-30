using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreShake : MonoBehaviour
{
    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;

    public bool isShaking;

    void Start()
    {
        startTime = Time.time;

        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    void Update()
    {
        if (isShaking)
        {
            //print("SHAKE");
            //float distCovered = (Time.time - startTime) * speed;
            //float fractionOfJourney = distCovered / journeyLength;
            //transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);

            StartCoroutine(Tremble());
        }
       
    }

    IEnumerator Tremble()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.localPosition += new Vector3(5f, 0, 0);
            yield return new WaitForSeconds(0.01f);
            transform.localPosition -= new Vector3(5f, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
}

