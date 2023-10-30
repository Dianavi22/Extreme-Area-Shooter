using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class PostProcess : MonoBehaviour
{
    public bool isGlitch = false;
    //public PostProcessVolume postProcessVolume;
    public PostProcessVolume postProcessVolumeScreenFade;
    static float t = 0.0f;

    private void Awake()
    {
        postProcessVolumeScreenFade.weight = 1;
        float test = postProcessVolumeScreenFade.weight;
    }
    void Start()
    {

    }

    void Update()
    {
        if (isGlitch)
        {
            test = Mathf.Lerp(1,0,t));

        }
        if (!isGlitch)
        {
            postProcessVolumeScreenFade.weight = 1;

        }

    }
}
