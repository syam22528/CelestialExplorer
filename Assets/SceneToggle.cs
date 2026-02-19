using UnityEngine;

public class SceneToggle : MonoBehaviour
{
    // Scene name to be loaded when this button is toggled
    [SerializeField] private string sceneName;

    // Public getter for the scene name
    public string GetSceneName()
    {
        return sceneName;
    }
}
