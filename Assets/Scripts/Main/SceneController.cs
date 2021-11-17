using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	PopTarget pop;
	int wait_frame = 0;
	public int clear_number;
	public static bool finished = false;
	public static bool is_in_practice = true;

	// Start is called before the first frame update
	void Start()
	{
		finished = false;
		pop = GameObject.Find("Pop").GetComponent<PopTarget>();
		wait_frame = 0;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (!pop.goal) {
			if (!finished) {
				++Counter.miss;
				finished = true;
			}
			++wait_frame;
			if (wait_frame >= 25) {
				if(Counter.clear + Counter.miss >= clear_number) {
					SceneManager.LoadScene("Result");
				}
				else {
					SceneManager.LoadScene("Calibration");
				}
			}
		}
	}

    void Update() {
		if (Input.GetKey(KeyCode.Escape))
			Quit();
	}
    public static void Quit() {
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#elif UNITY_STANDALONE
			UnityEngine.Application.Quit();
		#endif
	}
}
