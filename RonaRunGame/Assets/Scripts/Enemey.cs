using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.AI;

public class Enemey : MonoBehaviour
{
	// public VisualEffect vfx;
	public float wanderRadius;
	public float wanderTimer;
	private bool isVFXPlaying = false;
	private float timer;
	private NavMeshAgent agent;


	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
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
		Vector3 randDirection = Random.insideUnitSphere * dist;

		randDirection += origin;

		NavMeshHit navHit;

		NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

		return navHit.position;
	}
}
