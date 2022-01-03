using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultTimer : MonoBehaviour
{
	int clicking_frame = 0;
	Vector3 rot;
	// Start is called before the first frame update
	void Start()
	{
		rot = new Vector3(0, 0, 0);
		clicking_frame = 0;
	}

	void Update() {
		rot.z = -360.0f / 50 * clicking_frame;
		transform.rotation = Quaternion.Euler(rot);
	}

	void FixedUpdate() {
		if (Input.GetMouseButton(0)) {
			++clicking_frame;
		}
		else {
			clicking_frame = 0;
		}
		if (clicking_frame >= 50) {
			SceneManager.LoadScene("Title");
		}
	}
}
