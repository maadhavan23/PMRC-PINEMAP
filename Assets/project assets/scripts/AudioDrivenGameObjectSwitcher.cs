using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class GameObjectClip
{
    public GameObject gameObject;
    public float startTime;
    public float endTime;
}

public class AudioDrivenGameObjectSwitcher : MonoBehaviour
{
    public AudioSource audioSource;
    public List<GameObjectClip> gameObjectClips = new List<GameObjectClip>();

    void Start()
    {
        // Disable all GameObjects at the beginning
        foreach (var clip in gameObjectClips)
        {
            if (clip.gameObject != null)
                clip.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        float currentTime = audioSource.time;

        foreach (var clip in gameObjectClips)
        {
            if (clip.gameObject == null) continue;

            bool shouldBeActive = currentTime >= clip.startTime && currentTime < clip.endTime;

            if (clip.gameObject.activeSelf != shouldBeActive)
            {
                clip.gameObject.SetActive(shouldBeActive);
            }
        }
    }
}
