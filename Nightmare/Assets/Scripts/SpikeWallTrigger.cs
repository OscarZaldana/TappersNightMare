using UnityEngine;
using System.Collections;

public class SpikeWallTrigger : MonoBehaviour
{
	SpikeWall sw;

	void Start()
	{
		sw = transform.parent.gameObject.GetComponent<SpikeWall>();

		sw.SetEndPos (gameObject.GetComponent<BoxCollider>().size.y);
	}

	void OnTriggerEnter(Collider other)
	{
		print ("collided");
		if (other.gameObject.layer == 8)
		{
			print ("TRIGGERED");
			sw.Launch();
		}
	}
}
