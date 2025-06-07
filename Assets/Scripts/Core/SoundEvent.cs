using UnityEngine;

public abstract class SoundEvent
{
    public SoundType type;
    public AudioClip clip;
    public bool loop = false;

    public abstract void Play(AudioSource source);
}