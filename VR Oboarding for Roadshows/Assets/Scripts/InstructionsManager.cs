using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> instructionsBackground = new();
    [SerializeField] private List<AudioClip> instructionsAudio = new();
    [SerializeField] private AudioSource instructionsAudioSource;

    private void Start()
    {
        
    }
}
