using UnityEngine;
using System.Collections;

public class RulerText : MonoBehaviour {

	Transform ruler;
	string textBody;
	TextMesh text;
	public bool displayX;
	public bool displayY;
	public bool displayZ;


	// Use this for initialization
	void Start () {
	
		ruler = GetComponentInParent<Transform> ();
		text = GetComponent<TextMesh> ();

	}
	
	// Update is called once per frame
	void Update () {
	
		textBody = "";

		if (displayX) {
			textBody += "x: " + ruler.position.x.ToString () + "\n";
		}
		if (displayY) {
			textBody += "y: " + ruler.position.y.ToString () + "\n";
		}
		if (displayZ) {
			textBody += "z: " + ruler.position.z.ToString () + "\n";
		}

		text.text = textBody;

	}
}
