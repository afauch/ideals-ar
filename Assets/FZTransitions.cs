using UnityEngine;
using System.Collections;

public class FZTransitions : MonoBehaviour {

	public GameObject go;
	public float fadeTime;

	void Update ()
	{
		if(Input.GetKeyUp(KeyCode.T))
		{
			print ("T");
			StartCoroutine(FadeTo(go, 0.0f, fadeTime));
		}
		if(Input.GetKeyUp(KeyCode.F))
		{
			StartCoroutine(FadeTo(go,0.3f, fadeTime));
		}
	}

	public IEnumerator FadeTo(GameObject g, float aValue, float aTime)
	{

		print ("FadeTo coroutine started");

		// Create an array of all children
		Renderer[] allChildrenRenderers = g.GetComponentsInChildren<Renderer>();
		// print (allChildrenRenderers);

		float gR = g.GetComponent<Renderer> ().material.color.r;
		float gG = g.GetComponent<Renderer> ().material.color.g;
		float gB = g.GetComponent<Renderer> ().material.color.b;

		float alpha = g.transform.GetComponent<Renderer>().material.color.a;

		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{

			for (int i = 0; i < allChildrenRenderers.Length; i++) {

				Color newColor = new Color (gR, gG, gB, Mathf.Lerp (alpha, aValue, t));
				allChildrenRenderers[i].material.color = newColor;

			}
			yield return null;
		}
	}

}
