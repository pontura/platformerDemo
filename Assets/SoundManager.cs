using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	
	void Start () {
		Events.OnSoundFX += OnSoundFX;
	}
	void OnSoundFX(string audioName)
	{
		AudioSource source = gameObject.AddComponent<AudioSource>();
		source.clip = Resources.Load(audioName) as AudioClip;
		source.pitch = Mathf.Lerp( 0.4f, 1.5f, ((float)Random.Range (1, 10)/10) );
		source.Play();
		Destroy(source,1 );

	}
}
