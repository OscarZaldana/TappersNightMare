using UnityEngine;
using System.Collections;

public class WeepingAngel : MonoBehaviour
{
	public Transform player; //assign it
	public int maxHP = 5;
	public int curHP;

	NavMeshAgent nma;
	bool lookedAt;

	void Awake()
	{
		nma = gameObject.GetComponent<NavMeshAgent>();
	}

	void Start()
	{
		curHP = maxHP;
	}

	void Update()
	{
		transform.LookAt(player);

		// Figure out if the player is looking at it
		float fov = Camera.main.fieldOfView/2;
		float thetaView = Vector3.Angle(player.transform.forward, transform.position - player.transform.position);
		if (thetaView >= fov + 15)
            lookedAt = false;
		else
			lookedAt = true;

		if (!lookedAt)
			nma.destination = player.position;
		else 
			nma.destination = transform.position;
	}

	public void Hurt()
	{
		curHP -= 1;

		if (curHP <= 0)
			Destroy(gameObject);
	}
}
