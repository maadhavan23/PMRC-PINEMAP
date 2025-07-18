using UnityEngine;

public class MenuToggleTarget : MonoBehaviour
{
    [System.Serializable]
    public class ToggleTarget
    {
        public GameObject targetObject;
        public bool enableObject;
    }

    [Header("Toggle Settings")]
    public ToggleTarget[] targets;

    // This is what you call from your button's OnClick()
    public void ApplyToggles()
    {
        foreach (ToggleTarget toggle in targets)
        {
            if (toggle.targetObject != null)
            {
                toggle.targetObject.SetActive(toggle.enableObject);
            }
        }
    }
}
