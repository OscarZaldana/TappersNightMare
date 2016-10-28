using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float movespeed;

	public GameObject bullet;

	bool paused = false;
	bool hasWeapon = true;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab))	paused = !paused;
		if (!paused)
		{
			Cursor.lockState = CursorLockMode.Locked;
			float dX = Input.GetAxis("Mouse X") * .05f;
			float dY = Input.GetAxis("Mouse Y") * -.05f;

			Vector3 prev = transform.eulerAngles;
			transform.eulerAngles = new Vector3 (prev.x + (dY*Mathf.Rad2Deg), prev.y + (dX*Mathf.Rad2Deg), 0);

			if (Input.GetMouseButtonDown(0))	Shoot();

			float moveX = 0;
			float moveZ = 0;
			if (Input.GetKey(KeyCode.W))	moveZ += 1;
			if (Input.GetKey(KeyCode.S))	moveZ -= 1;
			if (Input.GetKey(KeyCode.A))	moveX -= 1;
			if (Input.GetKey(KeyCode.D))	moveX += 1;
			transform.Translate(new Vector3(moveX, 0, moveZ) * movespeed * Time.deltaTime);
			transform.position = new Vector3 (transform.position.x, 3, transform.position.z);
		}
		else 
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			transform.position = new Vector3 (transform.position.x, 3, transform.position.y);
		}
	}

	void Shoot()
	{
		Instantiate(bullet, new Vector3(transform.position.x, 2.5f, transform.position.z),
			Quaternion.Euler(transform.eulerAngles.x,transform.eulerAngles.y,0));
	}
}