using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Rigidbody sphere;
	public GameObject playerModel;

	public float rotate;
	public float speed;
	public float currentSpeed;
	public float currentRotate;
	public float steering = 80f;
	public float acceleration = 30f;

	// Update is called once per frame
	void Update()
	{
		// Make sure the player is inside the collider 
		transform.position = sphere.transform.position + new Vector3(0, .1f, 0);

		// Move Forward
		if (Input.GetKey(KeyCode.W))
			speed = acceleration;

		// Move Sideways
		float horizontal = Input.GetAxis("Horizontal");
		if (horizontal != 0)
		{
			int dir = horizontal > 0 ? 1 : -1;
			float amount = Mathf.Abs(horizontal);
			Steer(dir, amount);
		}

		currentSpeed = Mathf.SmoothStep(currentSpeed, speed, Time.deltaTime * 12f);
		speed = 0;
		currentRotate = Mathf.Lerp(currentRotate, rotate, Time.deltaTime * 4f); rotate = 0f;
		rotate = 0f;
	}

	private void FixedUpdate()
	{
		// Forward Acceleration / Decceleration
		sphere.AddForce(playerModel.transform.forward * currentSpeed, ForceMode.Acceleration);		

		// Steering
		transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y + currentRotate, 0), Time.deltaTime * 5f);
	}

	public void Steer(int direction, float amount)
	{
		rotate = (steering * direction) * amount;	
	}
}
