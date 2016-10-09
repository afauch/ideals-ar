using UnityEngine;
using System.Collections;

public class MoveTowards : MonoBehaviour {

	public GameObject objectToFollow;
	public float forceFactor;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
	
		rb = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {

		rb.AddForce((objectToFollow.transform.position - transform.position) * forceFactor * Time.smoothDeltaTime);

	}
}
