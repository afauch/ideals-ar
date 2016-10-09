using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class SpeechManager : MonoBehaviour
{

	public GameObject focusZone;

	KeywordRecognizer keywordRecognizer = null;
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

	// Use this for initialization
	void Start()
	{

		keywords.Add("Start", () =>
			{
				// Call the OnReset method on every descendant object.
				// this.BroadcastMessage("OnReset");

				GameObject.Find("FocusManager").GetComponent<FocusManager>().hasStarted = true;
				print("START");

			});

		keywords.Add("Help Me Focus", () =>
			{
				// Call the OnReset method on every descendant object.
				// this.BroadcastMessage("OnReset");

				// focusZone.transform.localScale = new Vector3(0.45f,0.45f,0.45f);
				StartCoroutine(LerpScale(1.0f,new Vector3(0.45f,0.45f,0.45f)));

				GameObject.Find("FocusManager").GetComponent<FocusManager>().hasStarted = false;
				focusZone.GetComponent<FZPosition>().hasBeenLocked = false;
				GameObject.Find("AudioMessages").GetComponent<AudioMessagesManager>().PlayClipOnGameObject("Set Sphere");
				print("HELP ME FOCUS");

			});

		keywords.Add("bigger", () =>
			{
				var focusObject = GazeGestureManager.Instance.FocusedObject;
				if (focusObject != null)
				{
					// Call the OnDrop method on just the focused object.
					// focusObject.SendMessage("OnDrop");



					Vector3 targetScale = focusZone.transform.localScale + new Vector3(0.2f,0.2f,0.2f);
					StartCoroutine(LerpScale(1.0f,targetScale));

					print("Make it bigger");


				}
			});

		keywords.Add("smaller", () =>
			{
				// Call the OnReset method on every descendant object.
				// this.BroadcastMessage("OnReset");

				focusZone.transform.localScale += new Vector3(-0.2f,-0.2f,-0.2f);

				print("Make it smaller");


			});

		keywords.Add("New Session", () =>
			{
				GameObject.Find("FocusManager").GetComponent<FocusManager>().hasStarted = false;
				GameObject.Find("FocusManager").GetComponent<FocusManager>().wasFocused = false;
				SceneManager.LoadScene("Positioning4");
			});

		// Tell the KeywordRecognizer about our keywords.
		keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

		// Register a callback for the KeywordRecognizer and start recognizing!
		keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
		keywordRecognizer.Start();

	}

	private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
	{
		System.Action keywordAction;
		if (keywords.TryGetValue(args.text, out keywordAction))
		{
			keywordAction.Invoke();
		}
	}

	// interpolation function
	IEnumerator LerpScale(float time, Vector3 ts) {

		Vector3 originalScale = focusZone.transform.localScale;
		Vector3 targetScale = ts;
		float originalTime = Time.time;

		while (time > 0.0f) {

			time -= Time.deltaTime;
			focusZone.transform.localScale = Vector3.Lerp (targetScale, originalScale, time / originalTime);

			yield return null;

		}
			
	}

}