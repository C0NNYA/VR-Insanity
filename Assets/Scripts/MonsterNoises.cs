using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MonsterGroanOnce : MonoBehaviour
{
    public AudioClip groanClip;
    public float delayBeforeGroan = 0f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = groanClip;
        audioSource.spatialBlend = 1f;

        if (groanClip != null)
        {
            Invoke(nameof(PlayGroan), delayBeforeGroan);
        }
    }

    void PlayGroan()
    {
        audioSource.Play();
    }
}