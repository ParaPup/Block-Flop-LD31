using UnityEngine;
using System.Collections;

public class TopScoredText : MonoBehaviour {

	private GameManager oGameManager;
	private GUIText gooey;

	// Use this for initialization
	void Start () {
		GameObject Temp = GameObject.Find("GameManager");
		oGameManager = Temp.GetComponent<GameManager>();
		gooey = GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "Top Score: " + oGameManager.topScore;
		if(oGameManager.playerAlive)
		{
			gooey.enabled = true;
		}
	
	}
}
