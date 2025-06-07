using UnityEngine;

public class LoopingSound : SoundEvent
{
    public override void Play(AudioSource source)
    {
        source.clip = clip;
        source.loop = true;
        source.Play();
    }
}
