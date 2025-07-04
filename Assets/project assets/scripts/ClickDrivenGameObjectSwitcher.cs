using UnityEngine;
using System.Collections.Generic;

public class ClickDrivenGameObjectSwitcher : MonoBehaviour
{
    [Header("GameObjects to cycle through")]
    public List<GameObject> objectsToCycle = new List<GameObject>();

    private int currentIndex = -1;

    void Start()
    {
        Debug.Log("ClickSwitcher started with " + objectsToCycle.Count + " objects.");

        foreach (var obj in objectsToCycle)
        {
            if (obj != null)
            {
                obj.SetActive(false);
                Debug.Log("Disabled: " + obj.name);
            }
            else
            {
                Debug.LogWarning("One of the entries in objectsToCycle is null!");
            }
        }
    }

    public void CycleToNext()
    {
        if (objectsToCycle.Count == 0)
        {
            Debug.LogWarning("No objects to cycle!");
            return;
        }

        // Disable current
        if (currentIndex >= 0 && currentIndex < objectsToCycle.Count && objectsToCycle[currentIndex] != null)
        {
            objectsToCycle[currentIndex].SetActive(false);
            Debug.Log("Deactivated: " + objectsToCycle[currentIndex].name);
        }

        // Increment and wrap around
        currentIndex = (currentIndex + 1) % objectsToCycle.Count;

        if (objectsToCycle[currentIndex] != null)
        {
            objectsToCycle[currentIndex].SetActive(true);
            Debug.Log("Activated: " + objectsToCycle[currentIndex].name);
        }
        else
        {
            Debug.LogWarning("Target GameObject at index " + currentIndex + " is null!");
        }
    }
}
