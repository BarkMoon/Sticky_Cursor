using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	PopTarget pop;
	int wait_frame = 0;
	public static bool finished = false;
	//public static bool cleared = true;
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
				++Counter.failure;
				//cleared = false;
				finished = true;
			}
			++wait_frame;
			if (wait_frame >= 25) {
				//Counter.elapsed_frame_result.Add(Counter.elapsed_frame);
				//Counter.clear_result.Add(cleared);
				//Counter.elapsed_frame = 0;
				if(!is_in_practice && Counter.finish >= Conditions.ClearNum) {
					SceneManager.LoadScene("Result");
				}
				else if(is_in_practice && Counter.finish >= Conditions.PracticeNum) {
					SceneManager.LoadScene("Explanation_2");
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
