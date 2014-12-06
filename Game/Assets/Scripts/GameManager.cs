using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject[] DropBlocks;
	public Vector3[] blockPos;
	public int safe;

	public double timer = 5;
	public double timerReset = 5;

	// Use this for initialization
	void Start () {
		DropBlocks = GameObject.FindGameObjectsWithTag ("DropBlock");
		for(int i = 0; i < DropBlocks.Length; i++){
			blockPos[i] = new Vector3(DropBlocks[i].transform.position);
		}
	}
	
	// Update is called once per frame
	void Update () {
		resetPos();
		if (timer > 0){
			timer -= Time.deltaTime;
		}
		if(timer <= 0){
			timeTill();
			timer = timerReset;
			dropIt();
		}
	}

	void dropIt(){
		
		for(int i = 0; i < DropBlocks.Length; i++)
		{
			//Debug.Log("Player Number "+i+" is named "+DropBlocks[i].name);
			DropBlocks[i].AddComponent("Rigidbody");
			safe = Random.Range(0, i);
			DropBlocks[i].gameObject.renderer.material.color = new Color(255, 0, 0, 255);
		}
		Debug.Log(safe);
		Destroy(DropBlocks[safe].GetComponent("Rigidbody"));
		DropBlocks[safe].gameObject.renderer.material.color = new Color(0, 255, 0, 255);
	}

	void timeTill(){
		if (timerReset > 1){
			timerReset = timerReset-0.1;
		}
	}

	void resetPos(){
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			for(int i = 0; i < DropBlocks.Length; i++)
			{
				DropBlocks[i].transform.position = blockPos[i];
			}
		}
	}

	void startRot(){
		for(int i = 0; i < DropBlocks.Length; i++)
		{
			
		}
	}
}