using UnityEngine;
using System.Collections;

public class FZPosition : MonoBehaviour {

	public bool hasBeenLocked;
	public GameObject focusZone;
	public GameObject cursor;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		print ("FZPosition hasbeenlocked " + hasBeenLocked);

		if (!hasBeenLocked) {

			focusZone.transform.position = cursor.transform.position;

		}

	}



}
