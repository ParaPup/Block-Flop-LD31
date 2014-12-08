using UnityEngine;
using System.Collections;

public class MassMurder : MonoBehaviour {

	private GameManager oGameManager;

	// Use this for initialization
	void Start () {

		GameObject Temp = GameObject.Find("GameManager");
		oGameManager = Temp.GetComponent<GameManager>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "Player")
		{
			//Destroy(col.gameObject);
		oGameManager.playerAlive = true;
		}
	}
}
