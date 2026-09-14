using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceanController : MonoBehaviour
{
    [SerializeField] PlayableDirector director;
    [SerializeField] GameObject Canvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(Canvas != null)
        {
            Canvas.SetActive(false);
        }
    }

    void OnEnable()
    {
        if (director != null)
        {
            director.stopped += OnCutsceneFinished;
        }
    }
    // Update is called once per frame
    void OnDisable()
    {
        if (director != null)
        {
            director.stopped -= OnCutsceneFinished;
        }
    }

    private void OnCutsceneFinished(PlayableDirector pd)
    {
        if (Canvas != null)
        {
            Canvas.SetActive(true);
        }
    }
}
