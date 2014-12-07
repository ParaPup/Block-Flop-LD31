using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject[] DropBlocks;
	public int safe;

	public GameObject block2Drop;

	public double timer = 5;
	public double timerReset = 5;

	// Use this for initialization
	void Start () {
		spawnBlocks();
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0){
			timer -= Time.deltaTime;
		}
		if(timer <= 0){
			timeTill();
			timer = timerReset;
			dropIt();
		}
	}

	void spawnBlocks(){
		for (int z = -5; z < 6; z++) {
			for (int x = -9; x < 10; x++) {
				GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				//cube.AddComponent<Rigidbody>();
				cube.tag = "DropBlock";
				cube.transform.position = new Vector3(x, 0, z);
			}
		}
		dropCheck();
		Debug.Log ("Spawn Blocks");
		print(DropBlocks[0]);
	}

	void dropCheck(){
		DropBlocks = GameObject.FindGameObjectsWithTag ("DropBlock");
		for(int i = 0; i < DropBlocks.Length; i++)
		{
			safe = Random.Range(0, i);
			DropBlocks[i].gameObject.renderer.material.color = new Color(255, 0, 0, 255);
		}
		DropBlocks[safe].gameObject.renderer.material.color = new Color(0, 255, 0, 255);
		Debug.Log ("DropCheck");
		print(DropBlocks[0]);
	}

	void dropIt(){
		//DropBlocks = GameObject.FindGameObjectsWithTag ("DropBlock");
		for(int i = 0; i < DropBlocks.Length; i++)
		{
			//Debug.Log("Player Number "+i+" is named "+DropBlocks[i].name);
			DropBlocks[i].AddComponent("Rigidbody");
			//safe = Random.Range(0, i);
			//DropBlocks[i].gameObject.renderer.material.color = new Color(255, 0, 0, 255);
		}
		Debug.Log(safe);
		Destroy(DropBlocks[safe].GetComponent("Rigidbody"));
		//DropBlocks[safe].gameObject.renderer.material.color = new Color(0, 255, 0, 255);
		StartCoroutine(killer());
		Debug.Log ("DropIT");
		print(DropBlocks[0]);
	}

	void timeTill(){
		if (timerReset > 3){
			timerReset = timerReset-0.1;
		}
	}

	void killBlocks(){
		Debug.Log ("Kill Blocks");
		//print(DropBlocks[0]);

//		int[] x = new int[10];
//		for (int i = 0; i < 10; i++)
//		{
//			x[i] = 5;
//		}
//		Array.Clear(x, 0, x.Length);

		//int[] x = new int[10];
		for (int i = 0; i < DropBlocks.Length; i++)
		{
			//DropBlocks[i] = 5;
		}
		//DropBlocks.Clear(DropBlocks, 0, DropBlocks.Length);

		for(int i = 0; i < DropBlocks.Length; i++)
		{
			Destroy(DropBlocks[i]);
		}

		DropBlocks = new GameObject[0];
		//print(DropBlocks[0]);


		//DropBlocks = new Array ();

		//spawnBlocks();
		StartCoroutine(respawner());
	}

	IEnumerator respawner ()
	{
		yield return new WaitForSeconds(0.1f);
		spawnBlocks();
	}

	IEnumerator killer ()
	{
		yield return new WaitForSeconds(2f);
		killBlocks();
	}
}