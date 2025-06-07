using UnityEngine;

public class OneShotSound : SoundEvent
{
    public override void Play(AudioSource source)
    {
        source.clip = clip;
        source.loop = false;
        source.Play();
    }
}
