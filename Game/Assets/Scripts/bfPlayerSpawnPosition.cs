using UnityEngine;
using System.Collections;

public class bfPlayerSpawnPosition : MonoBehaviour {
	public float PosX = 1f;
	public float PosY = 1f;
	public float PosZ = 1f;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (PosX, PosY, PosZ);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
