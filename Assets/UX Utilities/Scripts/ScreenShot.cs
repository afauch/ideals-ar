/*
using UnityEngine;
using System.Collections;
using System.IO;

// Attach this script directly to the Controller (left) or Controller (right) objects
// and configure the settings to take in-scene screenshots

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ScreenShot : MonoBehaviour {

	// Configurations
	public int screenshotScale;
	public bool grip;
	public bool trigger;
	public bool spacebar;

	private string path;
	private string imageName;
	private string dirName;

	SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;
	// Use this for initialization
	void Awake () {

		trackedObj = GetComponent<SteamVR_TrackedObject> ();
		//dvr = new DebugVR ();
		DebugVR.vrPrint("Screenshot class working");
		dirName = "Screenshots";
		MakeScreenshotDirectory (dirName);

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		device = SteamVR_Controller.Input((int)trackedObj.index);

		if(spacebar && Input.GetKeyUp("space"))
		{
			DebugVR.vrPrint("Spacebar");
			TakeScreenshot ();
		}
			
		if (device.GetPressUp (SteamVR_Controller.ButtonMask.Grip))
		{
			DebugVR.vrPrint("Grip Up");
			TakeScreenshot ();
		}

		if (trigger && device.GetTouch (SteamVR_Controller.ButtonMask.Trigger))
		{
			DebugVR.vrPrint("Trigger");
			TakeScreenshot ();
		}
	
	}

	void MakeScreenshotDirectory (string dirName) {

		DebugVR.vrPrint ("MakeScreenShotDirectory()");
		bool dirExists = System.IO.Directory.Exists (dirName);
		DebugVR.vrPrint (dirName + " directory exists? " + dirExists.ToString ());
		if (!dirExists) {
			System.IO.Directory.CreateDirectory (dirName);
			DebugVR.vrPrint ("Made directory: " + dirName);
		}

	}

	void TakeScreenshot () {
		int rand = Random.Range (1000,9999);
		imageName = "Screenshots" + System.DateTime.Now.ToString ("__yyyy-MM-dd") + rand.ToString () + ".png";
		path = System.IO.Path.Combine(@"Screenshots\",imageName);
		DebugVR.vrPrint (path.ToString ());
		Application.CaptureScreenshot(path, screenshotScale);
		DebugVR.vrPrint (imageName + " Saved.");

	}

}
*/