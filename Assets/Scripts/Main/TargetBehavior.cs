using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
	Vector3 pos;
	public float move_direction = 0f;       // Mathf.PI
	public float speed = 2.0f;          // 50fpsÇ»ÇÃÇ≈ÅA2Ç≈100px/s
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		pos = this.transform.position;
		pos.x += speed * Mathf.Cos(move_direction);
		pos.y += speed * Mathf.Sin(move_direction);
		this.transform.position = pos;
	}
}
