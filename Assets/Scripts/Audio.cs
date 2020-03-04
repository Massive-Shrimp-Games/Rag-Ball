using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private Dictionary<string, AudioSource> audioSources;

    private void Start()
    {
        GetChildren();
    }

    private void GetChildren()
    {
        audioSources = new Dictionary<string, AudioSource>();
        foreach (Transform child in transform)
        {
            audioSources.Add(child.name, child.GetComponent<AudioSource>());
        }
    }

    public void PlayAudio(string name)
    {
        audioSources[name]?.Play();
    }

    public void StopAudio()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<AudioSource>().Stop();
        }
    }
        public void StopSound(string name)
    {
        audioSources[name]?.Stop();
    }
}
