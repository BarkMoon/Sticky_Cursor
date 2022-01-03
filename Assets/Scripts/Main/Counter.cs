using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
	public static int clear = 0, miss = 0;
	public static int elapsed_frame = 0;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		gameObject.GetComponent<UnityEngine.UI.Text>().text = $"Clear {clear} / Miss {miss}";
	}

	void FixedUpdate()
	{
		if (!SceneController.finished)
			++elapsed_frame;
	}
}
