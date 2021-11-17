using System.Collections.Generic;
using UnityEngine;

public class PopTarget : MonoBehaviour
{
	int frame = 0;
	int XMAX, YMAX;
	public GameObject goal_target, dummy_target;
	public static int target_size = 100;
	public static int target_speed = 200;      // pixel / second
	public int dummy_num = 8;
	float speed_f;
	public TargetBehavior goal;
	TargetBehavior dummy;
	public List<TargetBehavior> dummies = new List<TargetBehavior>();

	// Start is called before the first frame update
	void Start()
	{
		frame = 0;
		speed_f = target_speed / 50.0f;
		XMAX = 600 + target_size / 2;
		YMAX = 450 + target_size / 2;

		//Random.InitState(0);        // óêêîÇÃèâä˙ÉVÅ[Éh

		int x, y;
		bool movement_x, is_plus;

		movement_x = (Random.Range(0, 2) == 1) ? true : false;
		is_plus = (Random.Range(0, 2) == 1) ? true : false;

		if (movement_x) {
			x = (is_plus) ? -XMAX : XMAX - 1;
			y = Random.Range(-450, 450);
			goal = Instantiate(goal_target, new Vector3(x, y, 0), Quaternion.identity).GetComponent<TargetBehavior>();
			if (y >= 0)
				goal.move_direction = (is_plus) ? Random.Range(-Mathf.PI * 0.25f, 0) : Random.Range(Mathf.PI, Mathf.PI * 1.25f);
			else
				goal.move_direction = (is_plus) ? Random.Range(0, Mathf.PI * 0.25f) : Random.Range(Mathf.PI * 0.75f, Mathf.PI);
		}
		else {
			x = Random.Range(-600, 600);
			y = (is_plus) ? -YMAX : YMAX - 1;
			goal = Instantiate(goal_target, new Vector3(x, y, 0), Quaternion.identity).GetComponent<TargetBehavior>();
			if (x >= 0)
				goal.move_direction = (is_plus) ? Random.Range(Mathf.PI * 0.5f, Mathf.PI * 0.75f) : Random.Range(Mathf.PI * 1.25f, Mathf.PI * 1.5f);
			else
				goal.move_direction = (is_plus) ? Random.Range(Mathf.PI * 0.25f, Mathf.PI * 0.5f) : Random.Range(-Mathf.PI * 0.5f, -Mathf.PI * 0.25f);
		}
		goal.transform.localScale = new Vector3(target_size, target_size, 1);
		goal.speed = speed_f;

		int x_dummy_num = Random.Range(0, dummy_num);

		for (int i = 0; i < dummy_num; ++i) {
			is_plus = (Random.Range(0, 2) == 1) ? true : false;
			if (i < x_dummy_num) {
				x = (is_plus) ? -XMAX : XMAX - 1;
				y = Random.Range(-450, 450);
				dummy = Instantiate(dummy_target, new Vector3(x, y, 0), Quaternion.identity).GetComponent<TargetBehavior>();
				if (y >= 0) 
					dummy.move_direction = (is_plus) ? Random.Range(-Mathf.PI * 0.25f, 0) : Random.Range(Mathf.PI, Mathf.PI * 1.25f);
				else
					dummy.move_direction = (is_plus) ? Random.Range(0, Mathf.PI * 0.25f) : Random.Range(Mathf.PI * 0.75f, Mathf.PI);
			}
			else {
				x = Random.Range(-600, 600);
				y = (is_plus) ? -YMAX : YMAX - 1;
				dummy = Instantiate(dummy_target, new Vector3(x, y, 0), Quaternion.identity).GetComponent<TargetBehavior>();
				if (x >= 0)
					dummy.move_direction = (is_plus) ? Random.Range(Mathf.PI * 0.5f, Mathf.PI * 0.75f) : Random.Range(Mathf.PI * 1.25f, Mathf.PI * 1.5f);
				else
					dummy.move_direction = (is_plus) ? Random.Range(Mathf.PI * 0.25f, Mathf.PI * 0.5f) : Random.Range(-Mathf.PI * 0.5f, -Mathf.PI * 0.25f);
			}
			dummy.transform.localScale = new Vector3(target_size, target_size, 1);
			dummy.speed = speed_f;
			dummies.Add(dummy);
		}

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (goal) {
			Vector3 pos = goal.transform.position;
			if (pos.x < -XMAX || pos.x >= XMAX || pos.y < -YMAX || pos.y >= YMAX) {
				Destroy(goal.gameObject);
			}
		}
		List<TargetBehavior> dummies_existing = new List<TargetBehavior>();
		foreach (TargetBehavior dm in dummies) {
			if (dm) {
				Vector3 pos = dm.transform.position;
				if (pos.x < -XMAX || pos.x >= XMAX || pos.y < -YMAX || pos.y >= YMAX) {
					Destroy(dm.gameObject);
				}
				else {
					dummies_existing.Add(dm);
				}
			}
		}
		dummies = new List<TargetBehavior>(dummies_existing);
		//Debug.Log(dummies.Count);
		++frame;
	}
}
