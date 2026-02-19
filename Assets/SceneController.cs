using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Transform content; // Reference to the Content object (parent of all toggles)
    public Animator animator;                   // Reference to the Animator component
    public GameObject fadeScreen;
    private static readonly int IsSpaceHash = Animator.StringToHash("isSpaceEnabled"); // Hash for animation parameter


    public WarpSpeedScriptTuT warpController;  // Reference to the WarpSpeedScriptTuT component

    void Start()
    {
        // Iterate over all toggles/buttons in the Content object
        foreach (Transform child in content)
        {
            // Check if the child has a SceneToggle component
            SceneToggle sceneToggle = child.GetComponent<SceneToggle>();
            Toggle toggle = child.GetComponent<Toggle>();

            if (sceneToggle != null && toggle != null)
            {
                // Add a listener to the toggle to load the scene
                toggle.onValueChanged.AddListener((isOn) =>
                {
                    if (isOn) // Only act when the toggle is turned ON
                    {
                        StartCoroutine(PlayAnimationAndLoadScene(sceneToggle.GetSceneName()));
                    }
                });
            }
            else
            {
                Debug.LogWarning($"Missing SceneToggle or Toggle on: {child.name}");
            }
        }
    }

    private IEnumerator PlayAnimationAndLoadScene(string sceneName)
    {
        Debug.Log("Starting animation and particle effects sequence.");

        // Start the animation
        animator.SetBool(IsSpaceHash, true);

        // Optional: Delay before starting the particle effect
        yield return new WaitForSeconds(5);

        // Activate the particle effect
        Debug.Log("Activating particle effect.");
        warpController.SetWarpActive();

        // Keep the particle effect active for the specified duration
        yield return new WaitForSeconds(15);

        Debug.Log("Deactivating particle effect.");
        warpController.SetWarpInactive();

        yield return new WaitForSeconds(1);

        // Flash animation
        Debug.Log("Starting flash animation.");
        yield return StartCoroutine(FlashQuad(1)); // 2 seconds for the flash

        // Switch to the new scene
        Debug.Log($"Loading scene: {sceneName}");
        LoadScene(sceneName);
    }

    private IEnumerator FlashQuad(float duration)
    {
        // Get the Renderer component of the fadeScreen (quad)
        Renderer quadRenderer = fadeScreen.GetComponent<Renderer>();

        if (quadRenderer == null)
        {
            Debug.LogError("fadeScreen does not have a Renderer component!");
            yield break;
        }

        // Get the material of the quad
        Material quadMaterial = quadRenderer.material;

        if (quadMaterial == null)
        {
            Debug.LogError("fadeScreen does not have a valid Material assigned!");
            yield break;
        }

        // Ensure the material supports transparency
        if (!quadMaterial.HasProperty("_BaseColor"))
        {
            Debug.LogError("Material does not have a _BaseColor property to manipulate alpha!");
            yield break;
        }

        // Smoothly increase the alpha value over the specified duration
        float elapsedTime = 0f;
        Color color = quadMaterial.GetColor("_BaseColor");

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, elapsedTime / duration);
            quadMaterial.SetColor("_BaseColor", new Color(color.r, color.g, color.b, alpha));
            yield return null;
        }

        // Ensure alpha is fully set
        quadMaterial.SetColor("_BaseColor", new Color(color.r, color.g, color.b, 1));
    }


    private void LoadScene(string sceneName)
    {
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError($"Scene '{sceneName}' not found in Build Settings.");
        }
    }
}
