using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform m_Target;

    [SerializeField]
    private float m_Speed;

    [SerializeField]
    private Vector3 m_Offset;

    public float duration = 1f;

    public static CameraController _cameraController;
    public bool shakeshake = false;

    [SerializeField] PlayerHealth _playerHealth;



    private void Awake()
    {
    }
    void Start()
    {

    }

    void Update()
    {
        try{
            transform.position = Vector3.Lerp(transform.position, m_Target.position + m_Offset, m_Speed * Time.deltaTime);
            if (shakeshake)
            {
                shakeshake = false;
                StartCoroutine(Shaking());
            }
        }
        catch { return; }
      
    }

    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = startPosition + Random.insideUnitSphere;

            yield return null;
        }
        _playerHealth.postProcessVolume.weight = 0;
        StopHurt();
        transform.position = startPosition;
    }

    public void StopHurt()
    {
        _playerHealth.lightHurt.SetActive(false);
        _playerHealth.hurtSideParticules1.Stop();
        _playerHealth.hurtSideParticules2.Stop();
        _playerHealth.hurtSideParticules3.Stop();
        _playerHealth.hurtSideParticules4.Stop();
    }
}
