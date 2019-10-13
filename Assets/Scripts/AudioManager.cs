using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource source;
    public static AudioSource Source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.playOnAwake = false;
        source.loop = false;
        Source = source;
    }

    public static void PlaySound(AudioClip clip)
    {
        Source.clip = clip;
        Source.Play();
    }
}
