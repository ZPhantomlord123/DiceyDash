using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioSource EffectsSource;
	public AudioSource MusicSource;

	[SerializeField] private List<AudioClip> _soundEffectClips;
	[SerializeField] private List<AudioClip> _musicClips;

	public float LowPitchRange = .95f;
	public float HighPitchRange = 1.05f;

	public static AudioManager instance = null;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}

		else if (instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

    private void Update()
    {
		SetSFXVolume();
		SetMusicVolume();
    }

    public void Play(string clip,float pitch)
	{
		for(int i = 0; i < _soundEffectClips.Count; i++)
        {
			if(_soundEffectClips[i].name == clip)
            {
				EffectsSource.clip = _soundEffectClips[i];
				EffectsSource.pitch = pitch;
				EffectsSource.Play();
			}
        }

	}

	public void PlayMusic(string clip,bool loop)
	{
		for (int i = 0; i < _musicClips.Count; i++)
		{
			if (_musicClips[i].name == clip)
			{
				MusicSource.clip = _musicClips[i];
				MusicSource.loop = loop;
				MusicSource.Play();
			}
		}

	}
	public void StopMusic(string clip)
	{
		for (int i = 0; i < _musicClips.Count; i++)
		{
			if (_musicClips[i].name == clip)
			{
				MusicSource.Stop();
			}
		}

	}

	public void RandomSoundEffect(params AudioClip[] clips)
	{
		int randomIndex = Random.Range(0, clips.Length);
		float randomPitch = Random.Range(LowPitchRange, HighPitchRange);

		EffectsSource.pitch = randomPitch;
		EffectsSource.clip = clips[randomIndex];
		EffectsSource.Play();
	}

	public void SetSFXVolume()
    {
		EffectsSource.volume = 1f;
		
    }
	public void SetMusicVolume()
	{
		MusicSource.volume = 1f;
	}
}
