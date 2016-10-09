using UnityEngine;

public class SphereCommands : MonoBehaviour
{

	public GameObject fzObject;

	// Called by GazeGestureManager when the user performs a Select gesture
	void OnSelect()
	{

		// toggle the lock
		bool locked = fzObject.GetComponent<FZPosition> ().hasBeenLocked;
		print ("Has been locked " + fzObject.GetComponent<FZPosition> ().hasBeenLocked);
		print ("locked var = " + locked);
		if (locked) {
			fzObject.GetComponent<FZPosition> ().hasBeenLocked = false;
			StartCoroutine(fzObject.GetComponent<FZTransitions> ().FadeTo (GameObject.Find("FZMesh"), 0.3f, 1.0f));
		} else {
			print ("ELSE");
			fzObject.GetComponent<FZPosition> ().hasBeenLocked = true;
			if (GameObject.Find ("FocusManager").GetComponent<FocusManager> ().hasStarted) {
				StartCoroutine (fzObject.GetComponent<FZTransitions> ().FadeTo (GameObject.Find ("FZMesh"), 0.0f, 1.0f));
			} 
			// if you haven't "started" yet - play the resize audio clip
			else {

				GameObject.Find ("AudioMessages").GetComponent<AudioMessagesManager> ().PlayClipOnGameObject ("Change Size");

			}
		}
			


		// print ("Selected");

		// If the sphere has no Rigidbody component, add one to enable physics.
		// if (!this.GetComponent<Rigidbody>())
		// {
		//	var rigidbody = this.gameObject.AddComponent<Rigidbody>();
		//	rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
		// }

		/*
		Renderer rend = GetComponent<Renderer> ();
		rend.material.shader = Shader.Find ("Standard");
		Color selectColor = new Color32 (0, 0, 255, 0);
		rend.material.SetColor("_Color", selectColor);
		*/

	}
}