using UnityEngine;
using System.Collections;

public class PlayerVoiceTrigger : MonoBehaviour 
{
	public AudioClip impact;
	AudioSource audio;
	
	void Start() 
	{
		audio = GetComponent<AudioSource>();
	}
	
	void OnTriggerEnter() 
	{
		audio.PlayOneShot(impact, 0.7F);

	}

}
