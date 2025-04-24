using UnityEngine;

public class TexturePulse : MonoBehaviour
{
    public Material pulseMaterial; // Assign the material using the blend shader
    public float pulseDuration = 1f;
    public string blendProperty = "_Blend"; // Match this to your shader’s blend property

    private Coroutine pulseCoroutine;

    public void TriggerPulse()
    {
        if (pulseCoroutine != null)
            StopCoroutine(pulseCoroutine);

        pulseCoroutine = StartCoroutine(PulseEffect());
    }

    private System.Collections.IEnumerator PulseEffect()
    {
        float halfTime = pulseDuration / 2f;
        float t = 0;

        // Fade in fiery texture
        while (t < halfTime)
        {
            t += Time.deltaTime;
            float blend = Mathf.Lerp(0, 1, t / halfTime);
            pulseMaterial.SetFloat(blendProperty, blend);
            yield return null;
        }

        // Fade back to normal texture
        t = 0;
        while (t < halfTime)
        {
            t += Time.deltaTime;
            float blend = Mathf.Lerp(1, 0, t / halfTime);
            pulseMaterial.SetFloat(blendProperty, blend);
            yield return null;
        }

        pulseMaterial.SetFloat(blendProperty, 0);
    }
}
