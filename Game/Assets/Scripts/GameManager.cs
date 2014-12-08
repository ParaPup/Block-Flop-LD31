using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject[] DropBlocks;
	public int safe;

	public GameObject block2Drop;

	public double timer = 9;
	public double timerReset = 6;

	public int scored;
	public int topScore;

	public int falls;

	public bool playerAlive;

	public AudioClip roundUp;

	private AudioSource gamemusic;

	private GameOver oGameOver;

	private TopScoredText oTopScoredText;

	private timesFell otimesFell;

	private CountDownS oCountDownS;

	private GameObject oPlayer;

	//private Player oplayer;

	// Use this for initialization
	void Start () {
		spawnBlocks();
		gamemusic = GetComponent<AudioSource>();

		GameObject Temp = GameObject.Find("gameOverT");
		oGameOver = Temp.GetComponent<GameOver>();

		GameObject Tempp = GameObject.Find("topScoredT");
		oTopScoredText = Tempp.GetComponent<TopScoredText>();

		GameObject Temppp = GameObject.Find("timesFallenT");
		otimesFell = Temppp.GetComponent<timesFell>();

		GameObject Tempppp = GameObject.Find("countDownT");
		oCountDownS = Tempppp.GetComponent<CountDownS>();
		
		oPlayer = GameObject.Find("Player");
		
		oCountDownS.countDown();
	}
	
	// Update is called once per frame
	void Update () {
		restart();
		if (timer > 0){
			timer -= Time.deltaTime;
		}
		if(timer <= 0){
			timeTill();
			timer = timerReset+3;
			dropIt();
		}
	}

	void FixedUpdate()
	{
		death();
	}

	void death(){
		if (playerAlive)
		{
			falls += 1;
			gamemusic.enabled = false;
			if (scored > topScore){
				topScore = scored;
			}
			Time.timeScale = 0.0001F;
		}
	}

	void restart(){
		if(Input.GetKeyDown(KeyCode.Tab)){
			Time.timeScale = 1;
			killBlocks();
			oCountDownS.countDown();
			scored = -1;
			timer = 6+3;
			timerReset = 6;
			playerAlive = false;
			oGameOver.GetComponent<GUIText>().enabled = false;
			oGameOver.GetComponent<AudioSource>().enabled = false;
			oTopScoredText.GetComponent<GUIText>().enabled = false;
			otimesFell.GetComponent<GUIText>().enabled = false;
			gamemusic.enabled = true;
			oPlayer.transform.position = new Vector3(0,2,0);
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
			DropBlocks[i].GetComponent<Rigidbody>().mass = 10000F;
		}
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
		yield return new WaitForSeconds(0.01f);
		spawnBlocks();
		scored = scored+1;
		audio.PlayOneShot(roundUp, 0.7F);
	}

	IEnumerator killer ()
	{
		yield return new WaitForSeconds(3f);
		killBlocks();
	}
}