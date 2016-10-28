using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public float bulletSpeed;
	float timer;

	void Update()
	{
		transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);

		timer += Time.deltaTime;
		if (timer >= 5)
			Destroy(gameObject);
	}

	void OnCollisionEnter(Collision other)
	{
		other.gameObject.SendMessage("Hurt");
	}
}
