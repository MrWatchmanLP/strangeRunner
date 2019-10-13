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
        source.pitch = 0.6f;
        Source = source;
    }

    public static void PlaySound(AudioClip clip)
    {
        Source.clip = clip;
        Source.Play();
    }

    public static void IncreasePitch()
    {
        if(Source.pitch < 2)
        {
            Source.pitch += 0.05f;
        }
    }
    public static void IncreasePitch(float inc)
    {
        Source.pitch += inc;
        if(Source.pitch < 1f)
        {
            Source.pitch = 1f;
        }
    }
}
