using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCursor : MonoBehaviour
{
	Vector3 last_mouse_position;
	// Start is called before the first frame update
	void Start()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		transform.position = new Vector3(0, 0, 0);
		last_mouse_position = Input.mousePosition;
	}

	// Update is called once per frame
	void Update()
	{
		if (Cursor.lockState == CursorLockMode.Locked) {
			last_mouse_position = Input.mousePosition;
		}

		Vector3 movement = Input.mousePosition - last_mouse_position;
		last_mouse_position = Input.mousePosition;
		transform.position += movement;

		if (transform.position.x < -600)
			transform.position = new Vector3(-600, transform.position.y, 0);
		if (transform.position.x > 600)
			transform.position = new Vector3(600, transform.position.y, 0);
		if (transform.position.y < -450)
			transform.position = new Vector3(transform.position.x, -450, 0);
		if (transform.position.y > 450)
			transform.position = new Vector3(transform.position.x, 450, 0);

		if (Input.mousePosition.x <= 0 || Input.mousePosition.x >= Screen.width - 1 || Input.mousePosition.y <= 0 || Input.mousePosition.y >= Screen.height - 1)
			Cursor.lockState = CursorLockMode.Locked;
		else
			Cursor.lockState = CursorLockMode.None;
	}
}
