using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.AI;
using System;

public class Enemey : MonoBehaviour
{
	// public VisualEffect vfx;
	public float wanderRadius;
	public float wanderTimer;
	public float lookAtPlayerDistance = 15f;
	private bool isVFXPlaying = false;
	private float timer;
	private NavMeshAgent agent;
	private GameObject player;

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
		//	vfx.Play();

		//if (isVFXPlaying)
		//	vfx.Play();
		//else
		//	vfx.pause = true;

		WalkAroundShop();

		if (Vector3.Distance(player.transform.position, transform.position) < lookAtPlayerDistance)
			LookAtPlayer();
    }

	private void LookAtPlayer()
	{
		transform.LookAt(player.transform);
	}

	private void WalkAroundShop()
	{
		timer += Time.deltaTime;
		if (timer >= wanderTimer)
		{
			MoveToRandomLocation();
		}
	}

	private void MoveToRandomLocation()
	{
		Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
		agent.SetDestination(newPos);
		timer = 0;
	}

	public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
	{
		Vector3 randDirection = UnityEngine.Random.insideUnitSphere * dist;

		randDirection += origin;

		NavMeshHit navHit;

		NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

		return navHit.position;
	}
}
