using UnityEngine;
using System.Collections;

public class SpikeWall : MonoBehaviour
{
	Vector3 restPos;
	Vector3 endPos;
	public float speed;
	public Transform player;

	public float moveTimer; // also works as a state machine. 0 for still, + for attacking, - for retreating

	void Start()
	{
		restPos = transform.position;
	}

	public void SetEndPos(float dist)
	{
		endPos = transform.position + this.transform.up * dist;
		print (endPos);
	}

	void Update()
	{
		if (moveTimer > 0)
		{ // if attacking
			moveTimer += Time.deltaTime;

			// minor interpolation on the speed
			float speedPercent = moveTimer / .5f;
			if (speedPercent > 1) speedPercent = 1;

			transform.Translate(Vector3.up * Time.deltaTime * (speed * Mathf.Lerp(.6f, 1, speedPercent)));

			if (Vector3.Distance(transform.position, endPos) < .5f)
				moveTimer = -moveTimer;
		}
		else if (moveTimer < 0)
		{ // if returning
			transform.Translate(Vector3.down * Time.deltaTime * (speed/4));

			if (Vector3.Distance(transform.position, restPos) < .1f)
				moveTimer = 0;
		}
	}

	public void Launch()
	{
		if (moveTimer == 0)
			moveTimer += Time.deltaTime;
	}
}
