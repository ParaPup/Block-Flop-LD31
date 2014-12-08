using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	private GameManager oGameManager;
	private GUIText gooey;
	private AudioSource gameEnd;
	
	// Use this for initialization
	void Start () {
		
		GameObject Temp = GameObject.Find("GameManager");
		oGameManager = Temp.GetComponent<GameManager>();

		gooey = GetComponent<GUIText>();
		gameEnd = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(oGameManager.playerAlive)
		{
			gooey.enabled = true;
			gameEnd.enabled = true;
		}
	}
}
