using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class WarpSpeedScriptTuT : MonoBehaviour
{
    public VisualEffect warpSpeedVFX; // Reference to the Visual Effect
    public float rate = 0.02f;        // Speed of warp amount increase/decrease

    private bool warpActive = false; // Tracks whether the warp is active

    void Start()
    {
        warpSpeedVFX.Stop();
        warpSpeedVFX.SetFloat("WarpAmount", 0);
    }

    public void SetWarpActive()
    {
        // Start coroutine to increase warp effect
        if (!warpActive)
        {
            warpActive = true;
            StartCoroutine(ActivateWarpEffect());
        }
    }

    public void SetWarpInactive()
    {
        // Start coroutine to decrease warp effect
        if (warpActive)
        {
            warpActive = false;
            StartCoroutine(DeactivateWarpEffect());
        }
    }

    private IEnumerator ActivateWarpEffect()
    {
        warpSpeedVFX.Play(); // Start the particle effect

        float amount = warpSpeedVFX.GetFloat("WarpAmount");
        while (amount < 1f && warpActive)
        {
            amount += rate;
            warpSpeedVFX.SetFloat("WarpAmount", Mathf.Clamp01(amount));
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator DeactivateWarpEffect()
    {
        float amount = warpSpeedVFX.GetFloat("WarpAmount");
        while (amount > 0f && !warpActive)
        {
            amount -= rate;
            warpSpeedVFX.SetFloat("WarpAmount", Mathf.Clamp01(amount));
            yield return new WaitForSeconds(0.1f);
        }

        if (amount <= 0f)
        {
            warpSpeedVFX.SetFloat("WarpAmount", 0);
            warpSpeedVFX.Stop(); // Stop the particle effect
        }
    }
}
