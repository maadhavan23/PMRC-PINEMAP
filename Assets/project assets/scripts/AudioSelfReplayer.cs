using UnityEngine;

public class AudioSelfReplayer : MonoBehaviour
{
    private AudioSource audioSource;

    void Awake()
    {
        // Automatically get the AudioSource attached to this object
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("No AudioSource found on this GameObject.");
        }
    }

    public void ReplayAudio()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.time = 0f;
            audioSource.Play();
        }
    }
}
