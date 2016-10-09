using UnityEngine;
using System.Collections;

public class FocusManager : MonoBehaviour {

	// Public GameObject cam;
	public bool isFocused;
	public bool wasFocused;
	public GameObject focusZone;
	public bool hasStarted;
	public float timeSinceFocus;
	public float timeSinceUnfocus;

	// Debug focus zone
	Renderer rend;
	Color onColor;
	Color offColor;

	// Use this for initialization
	void Start () {

		hasStarted = false;
		DebugColorSetup ();
		timeSinceFocus = 0;
		timeSinceUnfocus = 0;

	}
	
	// Update is called once per frame
	void Update () {
	
		isFocused = CheckGaze ();

		if (hasStarted) {


			if (isFocused) {

				// add to time
				timeSinceFocus += Time.deltaTime;
				if (focusZone.GetComponent<FZPosition> ().hasBeenLocked && !wasFocused) {
					print ("starting fade out");

						StartCoroutine (focusZone.GetComponent<FZTransitions> ().FadeTo (GameObject.Find ("FZMesh"), 0.0f, 1.0f));

					}
					timeSinceUnfocus = 0;
					wasFocused = isFocused;


				} else {

					timeSinceUnfocus += Time.deltaTime;
					float timeTransparency = timeSinceUnfocus * 2 / 100;
					timeTransparency = (timeTransparency > 0.3f) ? 0.3f : timeTransparency;
					// print (timeTransparency);
					StartCoroutine (focusZone.GetComponent<FZTransitions> ().FadeTo (GameObject.Find ("FZMesh"), timeTransparency, 1.0f));
					timeSinceFocus = 0;

					wasFocused = isFocused;

				}

				// Debug
				print ("Focused for " + timeSinceFocus);
				print ("Unfocused for " + timeSinceUnfocus);

			}

	}

	void DebugColorSetup() {

		// TODO: This is just debug
		rend = focusZone.GetComponent<Renderer> ();
		rend.material.shader = Shader.Find ("Standard");
		onColor = new Color32 (0, 255, 0, 50);
		offColor = new Color32 (255, 0, 0, 50);

	}

	bool CheckGaze() {

		// Do a raycast into the world based on the user's
		// head position and orientation.
		var headPosition = Camera.main.transform.position;
		var gazeDirection = Camera.main.transform.forward;

		RaycastHit hitInfo;

		if (Physics.Raycast (headPosition, gazeDirection, out hitInfo) && hitInfo.collider.gameObject.CompareTag("FocusZone")) {
			// If the raycast hit a hologram...
			// Display the cursor mesh.
			// meshRenderer.enabled = true;
			// print ("HIT");



			// TODO: Debug
			string collidedName = hitInfo.collider.gameObject.tag;
			DebugVR.vrPrintReplace ("You're focused on " + collidedName);

			// TODO: This is a debug
			rend.material.SetColor("_Color", onColor);
			return true;

			// Move the cursor to the point where the raycast hit.
			// this.transform.position = hitInfo.point;

			// Rotate the cursor to hug the surface of the hologram.
			// this.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
		} else {
			
			DebugVR.vrPrintReplace ("You're not focused!");
			rend.material.SetColor("_Color", offColor);
			return false;

		}

	}




}
