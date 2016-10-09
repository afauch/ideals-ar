using UnityEngine;
using System.Collections;

public static class DebugVR {

	static GameObject debugObj = GameObject.Find("DebugVR").gameObject;
	static TextMesh text = debugObj.GetComponent<TextMesh> ();

	public static void vrPrint (string logText) {

		// Debug.Log ("vrPrint running");
		text.text += logText + "\n";

	}

	public static void vrPrintReplace (string logText) {

		// Debug.Log ("vrPrint running");
		text.text = logText;

	}


}
