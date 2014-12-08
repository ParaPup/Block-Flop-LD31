using UnityEngine;
using System.Collections;

public class CountDownS : MonoBehaviour {

	public AudioClip beat;
	public AudioClip go;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void countDown(){
		StartCoroutine(ticker());
	}

	IEnumerator ticker()
	{
		GetComponent<GUIText>().enabled = true;
			guiText.text = "Ready";
		audio.PlayOneShot(beat, 1F);

		yield return new WaitForSeconds(1f);
			guiText.text = "Set";
		audio.PlayOneShot(beat, 1F);

		yield return new WaitForSeconds(1f);
			guiText.text = "Go!";
		audio.PlayOneShot(beat, 1F);

		yield return new WaitForSeconds(1f);
			GetComponent<GUIText>().enabled = false;
		audio.PlayOneShot(go, 1F);
	}
}
