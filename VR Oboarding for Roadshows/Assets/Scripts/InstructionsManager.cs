using System;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsManager : MonoBehaviour
{
    [Serializable]
    private struct InstructionsAudioPair
    {
        public GameObject instructions;
        public AudioClip narrationAudioClip;
    }

    [SerializeField] private List<InstructionsAudioPair> instructionsAudioPairs;

    private Dictionary<GameObject, AudioClip> audioMappings;
    private AudioSource audioSource;
    private int currentCanvasIndex = 0;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    { 
        audioMappings = new Dictionary<GameObject, AudioClip>();

        // Populate the dictionary from the serilized list
        foreach (var pair in instructionsAudioPairs)
        {
            audioMappings.Add(pair.instructions, pair.narrationAudioClip);

            // Add listener for instruction activation
            InstructionActivationListener listener = pair.instructions.AddComponent<InstructionActivationListener>();
            listener.Initialize(this);
            // Deactivate all instructions
            pair.instructions.SetActive(false);
        }

        // Activate the first instruction
        if (instructionsAudioPairs.Count > 0)
            ActivateInstruction(0);
    }

    private void OnAudioComplete()
    {
        currentCanvasIndex++;
        if (currentCanvasIndex < instructionsAudioPairs.Count)
            ActivateInstruction(currentCanvasIndex);
    }

    // Method to play audio for a specific instruction
    public void PlayAudio(GameObject instruction)
    {   
        if (audioMappings.TryGetValue(instruction, out AudioClip clip))
        {
            audioSource.clip = clip;
            audioSource.Play();
            // Schedule the OnAudioComplete method
            Invoke(nameof(OnAudioComplete), clip.length); 
        }
        else
        {
            Debug.LogWarning("No audio clip found for the specified instruction object.");
        }
    }

    private void ActivateInstruction(int index)
    {
        for (int i = 0; i < instructionsAudioPairs.Count; i++)
            instructionsAudioPairs[i].instructions.SetActive(i == index);
    }

    public class InstructionActivationListener : MonoBehaviour
    {
        private InstructionsManager instructionManager;
            
        public void Initialize(InstructionsManager manager)
        {
            instructionManager = manager;
        }

        void OnEnable()
        {
            if (instructionManager != null)
                // Play audio when the instruction is activated
                instructionManager.PlayAudio(gameObject);
        }
    }

}
