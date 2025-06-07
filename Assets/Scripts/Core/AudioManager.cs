using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AudioManager : SerializedMonoBehaviour
{
    [BoxGroup("Audio Sources")]
    public AudioSource musicSource;

    [BoxGroup("Audio Sources")]
    public AudioSource sfxSource;

    [BoxGroup("Sound Events")]
    public List<SoundEvent> soundEvents;

    private static float savedVolume = 1f;
    private void Awake()
    {
        savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        Debug.Log($"громкость в игре: {savedVolume}");

        if (musicSource != null)
            musicSource.volume = savedVolume;

        if (sfxSource != null)
            sfxSource.volume = savedVolume;
    }

    public void PlaySound(SoundType soundType)
    {
        var soundEvent = soundEvents.FirstOrDefault(s => s.type == soundType);
        if (soundEvent == null)
        {
            Debug.LogWarning($"Не найден звук для типа: {soundType}");
            return;
        }

        var source = soundEvent.loop ? musicSource : sfxSource;
        soundEvent.Play(source);
    }

    public void StopMusic()
    {
        musicSource?.Stop();
    }
}
