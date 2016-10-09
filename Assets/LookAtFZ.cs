using UnityEngine;
using System.Collections;

public class LookAtFZ : MonoBehaviour {

	public GameObject focusZone;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.LookAt(focusZone.transform.position);

	}
}
