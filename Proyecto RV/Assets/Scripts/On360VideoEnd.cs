using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class On360VideoEnd : MonoBehaviour
{
    private VideoPlayer vp;
    public GameObject canvas;
    void Start()
    {
        vp = GetComponent<VideoPlayer>();
    }

    void Update()
    {
        if (!vp.isPlaying)
        {
            if(canvas.activeSelf) canvas.SetActive(true);
        }
    }
}
