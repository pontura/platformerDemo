using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	
	void Start () {
		Events.OnSoundFX += OnSoundFX;
	}
	void OnDestroy () {
		Events.OnSoundFX -= OnSoundFX;
	}
	void OnSoundFX(string audioName)
	{
		AudioSource source = gameObject.AddComponent<AudioSource>();
		AudioClip clip = Resources.Load(audioName) as AudioClip;
		source.clip = clip;
		source.pitch = Mathf.Lerp( 0.4f, 1.5f, ((float)Random.Range (1, 10)/10) );
		source.Play();
		Destroy (source, source.clip.length);
	}
}
