using UnityEngine;

public class ShoppingCartMovement : MonoBehaviour
{
	public float accerlationSpeed = 500f;
	public float rotationSpeed = 100f;
	private Rigidbody rb;
	public Vector3 movement;
	public Vector3 rotation;

	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody>();
	}

	private void Update()
	{
		// Acceleration
		movement = new Vector3(0, 0, Input.GetAxis("Vertical"));

		// Rotation
		rotation = new Vector3(0, Input.GetAxis("Horizontal"), 0);
	}


	void FixedUpdate()
	{
		movePlayer(movement, rotation);
	}

	void movePlayer(Vector3 direction, Vector3 rotation)
	{
		rb.AddRelativeForce(direction * accerlationSpeed * Time.deltaTime);
		transform.Rotate(rotation * rotationSpeed * Time.deltaTime);
	}
}
