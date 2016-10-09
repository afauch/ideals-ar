using UnityEngine;
using System.Collections;

public class XDManager : MonoBehaviour {

	public GameObject focusManager;
	private FocusManager fm;
	public AudioMessagesManager am;

	[Header("Delay Control")]
	public float shortDelay;
	public float longDelay;

	// Focus levels
	/*
	enum focusLevels {
		focused,
		semifocused,
		unfocused
	};
	*/

	// Use this for initialization
	void Start () {

		InitializeFocusManager ();

	}
	
	// Update is called once per frame
	void Update () {

		InteractionSwitch ();

	}

	void InitializeFocusManager() {

		// Assign 'fm' to be the FocusManager script sitting on the FocusManager GameObject.
		fm = focusManager.GetComponent<FocusManager> (); 

	}
		

	// This takes the focus level as an input

	void InteractionSwitch() {

		// If you're unfocused
		if (fm.isFocused == false) {


			// Short delay only
			if (fm.timeSinceUnfocus > shortDelay && fm.timeSinceFocus < longDelay) {


				// play the audio clip
				am.PlayClipOnGameObject ("Distraction Alert");


			}

			if (fm.timeSinceUnfocus > longDelay) {

				// play the audio clip
				am.PlayClipOnGameObject ("Time Warning");

			}

		} else { // If you're focused, reset the clip plays

			// Reset Clip Plays
			ResetClipPlays();

		}
				

	}

	// only do this on 'focus'
	void ResetClipPlays() {

		DebugVR.vrPrint ("ResetClipPlays called");

		// Reset all 'unfocused' clip plays
		for (int i = 0; i < am.unfocusClips.Length; i++) {

			// reset the 'hasPlayedThisSession' Boolean
			am.unfocusClips [i].GetComponent<AudioMessage> ().hasPlayedThisSession = false;
		
		}

	}

}
