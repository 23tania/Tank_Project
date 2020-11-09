using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;  // !!!!!!!!!

public class PostProcessingController : MonoBehaviour
{
    private PostProcessVolume ppVolume;

    // Start is called before the first frame update
    void Start()
    {
        ppVolume = GameObject.Find("PostProcessing").GetComponent<PostProcessVolume>();
    }

    public void BlurAtRuntime()
    {
        // Adding bluring effect
        DepthOfField depthOfField = ScriptableObject.CreateInstance<DepthOfField>();
        depthOfField.active = true;
        depthOfField.enabled.Override(true);
        depthOfField.aperture.Override(20.0f);
        depthOfField.focalLength.Override(65.0f);
        depthOfField.focusDistance.Override(1.0f);
        ppVolume = PostProcessManager.instance.QuickVolume
            (GameObject.Find("PostProcessing").layer, 0f, depthOfField);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
