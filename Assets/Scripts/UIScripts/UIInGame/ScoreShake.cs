using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreShake : MonoBehaviour
{
    //public Transform startMarker;
    //public Transform endMarker;
    //public float speed = 4F;
    //private float startTime;
    //private float journeyLength;

    public float speed;
    public float amount;

    public bool isShaking;

    void Start()
    {
       // startTime = Time.time;
       // journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    void Update()
    {
        if (isShaking)
        {
            //print("SHAKE");
            //float distCovered = (Time.time - startTime) * speed;
            //float fractionOfJourney = distCovered / journeyLength;
            //transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);

            // StartCoroutine(Tremble());

            //transform.position = new Vector3(Mathf.Sin(Time.time * speed) * amount, transform.position.y, transform.position.z);
            Shaking();
        }

    }

    IEnumerator Tremble()
    {
        for (int i = 0; i < 10; i++)
        {

            transform.localPosition += new Vector3(0.2f, 0.2f, 0.2f);
            yield return new WaitForSeconds(0.01f);
            transform.localPosition -= new Vector3(-0.2f, 0.2f, 0.2f);
            yield return new WaitForSeconds(0.01f); 
            transform.localPosition += new Vector3(-0.2f, -0.2f, 0.2f);
            yield return new WaitForSeconds(0.01f);
            transform.localPosition -= new Vector3(0.2f, -0.2f, 0.2f);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < 1)
        {
            elapsedTime += Time.deltaTime;
            transform.position = startPosition + Random.insideUnitSphere;

            yield return null;
        }
        transform.position = startPosition;
    }
}

