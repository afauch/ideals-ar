using UnityEngine;
using System.Collections;

public class AudioMessagesManager : MonoBehaviour {

	public bool audioIsPlaying;
	public AudioListener listener;

	public GameObject[] unfocusClips;
	public GameObject[] focusClips;

	// Use this for initialization
	void Start () {
	
		audioIsPlaying = false;

	}
	
	// Update is called once per frame
	void Update () {

		// check if audio is playing


	}


	public void PlayClipOnGameObject(string name) {

		print ("Playing clip " + name);
		AudioSource src = GameObject.Find (name).GetComponent<AudioSource> ();
		AudioMessage am = src.gameObject.GetComponent<AudioMessage> ();
		if(!src.isPlaying && !am.hasPlayedThisSession){
			src.Play ();
			am.hasEverPlayed = true;
			am.hasPlayedThisSession = true;
		}


	}

}
