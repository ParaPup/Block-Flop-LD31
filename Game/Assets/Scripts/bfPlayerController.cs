using UnityEngine;
using System.Collections;

public class bfPlayerController : MonoBehaviour {
	public float moveSpeed = 5;
	public float JumpHeight = 30;

	public bool grounded = false;

	public GameObject oCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update (){
		screenLock();
	}

	void FixedUpdate(){
		jumper();
		movement();
	}

	void OnCollisionEnter(Collision collision){
		grounded = true;
	}

	void jumper(){
		if (grounded){
			if (Input.GetAxis("Jump") >0){
				rigidbody.AddForce( 0, JumpHeight, 0);
				grounded = false;
			}
		}
	}

	void movement(){
		//Forward
		if (Input.GetAxis("Vertical") >0) 
		{
			transform.localPosition += transform.forward * Time.deltaTime * moveSpeed;		
		}
		
		//Backwards
		if (Input.GetAxis("Vertical") <0)
		{
			transform.localPosition += -transform.forward * Time.deltaTime * moveSpeed;		
		}

		//Left
		if (Input.GetAxis("Horizontal") <0) 
		{
			transform.localPosition += -transform.right * Time.deltaTime * moveSpeed;		
		}
		
		//Right
		if (Input.GetAxis("Horizontal") >0) 
		{
			transform.localPosition += transform.right * Time.deltaTime * moveSpeed;		
		}
	}

	void screenLock(){
		Vector3 ScreenPos = oCamera.GetComponent<Camera>().WorldToViewportPoint(transform.position);
		if (ScreenPos.x < 0)
		{
			ScreenPos.x = 0;
			transform.position = oCamera.GetComponent<Camera>().ViewportToWorldPoint(ScreenPos);
			rigidbody.velocity = Vector3.zero;
		}
		else if (ScreenPos.x > 1)
		{
			ScreenPos.x = 1;
			transform.position = oCamera.GetComponent<Camera>().ViewportToWorldPoint(ScreenPos);
			rigidbody.velocity = Vector3.zero;
		}
		if (ScreenPos.y < 0)
		{
			ScreenPos.y = 0;
			transform.position = oCamera.GetComponent<Camera>().ViewportToWorldPoint(ScreenPos);
			rigidbody.velocity = Vector3.zero;
		}
		else if (ScreenPos.y > 1)
		{
			ScreenPos.y = 1;
			transform.position = oCamera.GetComponent<Camera>().ViewportToWorldPoint(ScreenPos);
			rigidbody.velocity = Vector3.zero;
		}
	}
}