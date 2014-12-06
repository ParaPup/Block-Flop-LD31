using UnityEngine;
using System.Collections;

public class bfPlayerController : MonoBehaviour {
	public float moveSpeed = 10f;
	public float jumpSpeed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey ("w") == true) 
			{
				transform.localPosition += transform.forward * Time.deltaTime * moveSpeed;		
			}
		if (Input.GetKey ("a") == true) 
		{
			transform.localPosition += -transform.right * Time.deltaTime * moveSpeed;		
		}
		if (Input.GetKey ("s") == true) 
		{
			transform.localPosition += -transform.forward * Time.deltaTime * moveSpeed;		
		}
		if (Input.GetKey ("d") == true) 
		{
			transform.localPosition += transform.right * Time.deltaTime * moveSpeed;		
		}
	
	}
}