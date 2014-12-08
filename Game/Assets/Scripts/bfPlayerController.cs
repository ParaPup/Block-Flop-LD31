using UnityEngine;
using System.Collections;

public class bfPlayerController : MonoBehaviour {
	public float moveSpeed = 5;
	public float JumpHeight = 30;

	public bool grounded = false;

	public GameObject oCamera;

	public const float fMaxAccel = 120;
	public const float fMinAccel = 120;

	public const float fMaxVelocity = 30;

	private float fAccelMag = 0;
	private float fAccelX = 0;
	private float fAccelY = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update (){
		screenLock();
		SetAccelMag();
		SetAccelX();
		SetAccelY();
		ScaleAccel();
		Move();
	}

	void FixedUpdate(){
		jumper();
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

	void SetAccelMag()
	{
		fAccelMag = fMaxAccel;
		if (fAccelMag < fMinAccel)
		{
			fAccelMag = fMinAccel;
		}
	}
	
	void SetAccelX()
	{
		fAccelX = 0;

		if (Input.GetKey(KeyCode.D))
		{
			fAccelX += fAccelMag;
		}
		
		if (Input.GetKey(KeyCode.A))
		{
			fAccelX -= fAccelMag;
		}
	}
	
	void SetAccelY()
	{
		fAccelY = 0;

		if (Input.GetKey(KeyCode.W))
		{
			fAccelY += fAccelMag;
		}
		
		if (Input.GetKey(KeyCode.S))
		{
			fAccelY -= fAccelMag;
		}
	}
	
	void ScaleAccel()
	{
		if (Mathf.Abs(fAccelX) + Mathf.Abs(fAccelY) > fAccelMag)
		{
			fAccelX = fAccelX / 2;
			fAccelY = fAccelY / 2;
		}
	}

	void Move()
	{
		rigidbody.AddForce(Vector3.forward * fAccelY);
		rigidbody.AddForce(Vector3.right * fAccelX);
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