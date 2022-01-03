using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehavior : MonoBehaviour
{
	public static bool is_sticky = false;
	public Sprite normal, push;
	SpriteRenderer sprite_renderer;
	PopTarget pop;
	int target_size;
	Counter counter;
	GameObject finish_text;
	Vector3 last_mouse_position;
	float speed, move_direction;
	bool touching;
	int wait_frame;

	// Start is called before the first frame update
	void Start()
	{
		sprite_renderer = gameObject.GetComponent<SpriteRenderer>();
		sprite_renderer.sprite = normal;
		pop = GameObject.Find("Pop").GetComponent<PopTarget>();
		target_size = PopTarget.target_size;
		counter = GameObject.Find("Counter").GetComponent<Counter>();
		finish_text = GameObject.Find("FinishText");
		finish_text.SetActive(false);

		Cursor.visible = false;

		//transform.position = Input.mousePosition + new Vector3(-600, -450, 0);
		transform.position = Timer.cursor_position;
		last_mouse_position = Input.mousePosition;

		speed = 0;
		move_direction = 0;

		wait_frame = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if(Cursor.lockState == CursorLockMode.Locked) {
			last_mouse_position = Input.mousePosition;
		}
		if (is_sticky) {
			Vector3 movement = Input.mousePosition - last_mouse_position;
			last_mouse_position = Input.mousePosition;
			transform.position += movement;

			Vector3 pos = transform.position;
			pos.x += speed * Mathf.Cos(move_direction);
			pos.y += speed * Mathf.Sin(move_direction);
			transform.position = pos;

			float distance_d, distance_g;
			touching = false;
			foreach (TargetBehavior dummy in pop.dummies) {
				if (dummy) {
					distance_d = Vector3.Distance(transform.position, dummy.transform.position);
					if (distance_d <= target_size / 2) {
						speed = dummy.speed * Time.deltaTime / Time.fixedDeltaTime;
						move_direction = dummy.move_direction;
						sprite_renderer.sprite = push;
						touching = true;
					}
				}
			}
			if (pop.goal) {
				distance_g = Vector3.Distance(transform.position, pop.goal.transform.position);
				if (distance_g <= target_size / 2) {
					speed = pop.goal.speed * Time.deltaTime / Time.fixedDeltaTime;
					move_direction = pop.goal.move_direction;
					sprite_renderer.sprite = push;
					touching = true;
				}
			}
			if (!touching) {
				speed = 0;
				move_direction = 0;
				sprite_renderer.sprite = normal;
			}
		}
		else {
			Vector3 movement = Input.mousePosition - last_mouse_position;
			last_mouse_position = Input.mousePosition;
			transform.position += movement;

			float distance_d, distance_g;
			touching = false;
			foreach (TargetBehavior dummy in pop.dummies) {
				if (dummy) {
					distance_d = Vector3.Distance(transform.position, dummy.transform.position);
					if (distance_d <= target_size / 2) {
						sprite_renderer.sprite = push;
						touching = true;
					}
				}
			}
			if (pop.goal) {
				distance_g = Vector3.Distance(transform.position, pop.goal.transform.position);
				if (distance_g <= target_size / 2) {
					sprite_renderer.sprite = push;
					touching = true;
				}
			}
			if (!touching) {
				sprite_renderer.sprite = normal;
			}
		}

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

		if (!SceneController.finished && Input.GetMouseButtonDown(0) && pop.goal) {
			int failure = 0;
			float distance_d, distance_g;
			foreach (TargetBehavior dummy in pop.dummies) {
				if (dummy) {
					distance_d = Vector3.Distance(transform.position, dummy.transform.position);
					if (distance_d <= target_size / 2) {
						++failure;
					}
				}
			}
			distance_g = Vector3.Distance(transform.position, pop.goal.transform.position);
			//Debug.Log(distance_g);
			if (distance_g > target_size / 2) {
				++failure;
			}
			if(failure == 0) {      // ê¨å˜
				++Counter.clear;
				SceneController.cleared = true;
				pop.goal.GetComponent<SpriteRenderer>().color = new Color(0, 1.0f, 0);
				finish_text.GetComponent<UnityEngine.UI.Text>().text = "Success!";
				finish_text.SetActive(true);
			}
			else {
				++Counter.miss;
				SceneController.cleared = false;
				finish_text.GetComponent<UnityEngine.UI.Text>().text = "Failed";
				finish_text.SetActive(true);
			}
			SceneController.finished = true;
		}
	}

	void FixedUpdate() {
		if (SceneController.finished)
			++wait_frame;
		if (wait_frame == 50) {
			gameObject.SetActive(false);
		}
	}

}
