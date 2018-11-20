using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerenciador : MonoBehaviour {

	public AudioSource sons;
	public static Gerenciador inst = null;

	// Use this for initialization
	void Awake () {
		
		if (inst == null) {
			inst = this;
		} else if (inst != this) {
			Destroy (gameObject);
		}

	}

	public void PlayAudio(AudioClip clipAudio) {

		sons.clip = clipAudio;
		sons.Play ();

	}

}
