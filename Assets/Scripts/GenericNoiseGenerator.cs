using UnityEngine;
using System.Collections;

public class GenericNoiseGenerator : MonoBehaviour {
	public AudioClip audioClip;
	ParticleSystem particleSystem;
	public float ParticlePlayTime=0.5f;
	private float particleStartTime;
	// Use this for initialization
	void Start () {
		particleSystem = GetComponent <ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (particleSystem&&particleSystem.isPlaying) {
			if(Time.realtimeSinceStartup>particleStartTime+ParticlePlayTime){
				particleSystem.Stop ();
			}
		}
	}
	void OnCollisionEnter(Collision other){
		AudioSource audio=GetComponent<AudioSource> ();
		if(audioClip!=null&&audio!=null){
			audio.PlayOneShot (audioClip);
		}
		ParticleSystem particleSystem = GetComponent <ParticleSystem> ();
		if(particleSystem!=null){
			particleSystem.Play ();
			particleStartTime = Time.realtimeSinceStartup;
		}

	}
}
