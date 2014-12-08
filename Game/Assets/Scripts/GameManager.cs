using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject[] DropBlocks;
	public int safe;

	public GameObject block2Drop;

	public double timer = 5;
	public double timerReset = 5;

	public int scored;

	public bool playerAlive;

	public AudioClip roundUp;

	private AudioSource gamemusic;

	// Use this for initialization
	void Start () {
		spawnBlocks();

		gamemusic = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		restart();
		death();
		if (timer > 0){
			timer -= Time.deltaTime;
		}
		if(timer <= 0){
			timeTill();
			timer = timerReset;
			dropIt();
		}
	}

	void death(){
		if (playerAlive)
		{
			gamemusic.enabled = false;
			Time.timeScale = 0.00001F;
		}
	}

	void restart(){
		if(Input.GetKeyDown(KeyCode.Tab)){
			Application.LoadLevel (0);
		}
	}

	void spawnBlocks(){
		for (int z = -5; z < 6; z++) {
			for (int x = -9; x < 10; x++) {
				Instantiate(block2Drop, new Vector3(x, 0, z), Quaternion.identity);
			}
		}
		dropCheck();
	}

	void dropCheck(){
		DropBlocks = GameObject.FindGameObjectsWithTag ("DropBlock");
		for(int i = 0; i < DropBlocks.Length; i++)
		{
			safe = Random.Range(0, i);
			//DropBlocks[i].gameObject.renderer.material.color = new Color(255, 0, 0, 255);
		}
		DropBlocks[safe].gameObject.renderer.material.color = new Color(0, 255, 0, 255);
	}

	void dropIt(){
		for(int i = 0; i < DropBlocks.Length; i++)
		{
			DropBlocks[i].AddComponent("Rigidbody");
		}
		Debug.Log(safe);
		Destroy(DropBlocks[safe].GetComponent("Rigidbody"));
		StartCoroutine(killer());
	}

	void timeTill(){
		if (timerReset > 3){
			timerReset = timerReset-0.1;
		}
	}

	void killBlocks(){

		for(int i = 0; i < DropBlocks.Length; i++)
		{
			Destroy(DropBlocks[i]);
		}

		DropBlocks = new GameObject[0];

		StartCoroutine(respawner());
	}

	IEnumerator respawner ()
	{
		yield return new WaitForSeconds(0.1f);
		spawnBlocks();
		scored = scored+1;
		audio.PlayOneShot(roundUp, 0.7F);
	}

	IEnumerator killer ()
	{
		yield return new WaitForSeconds(2f);
		killBlocks();
	}
}