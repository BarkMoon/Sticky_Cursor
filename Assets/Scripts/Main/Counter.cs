using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
	public static int success = 0, failure = 0, click_on_dummy = 0, click_on_empty_space = 0, finish = 0;
	public static int elapsed_frame = 0;
	//public static List<int> elapsed_frame_result;
	//public static List<bool> clear_result;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		gameObject.GetComponent<UnityEngine.UI.Text>().text = $"Success {success} / Failure {failure} / Dummy {click_on_dummy} / Empty {click_on_empty_space}";
	}

	void FixedUpdate()
	{
		if (!SceneController.finished)
			++elapsed_frame;
	}
}
