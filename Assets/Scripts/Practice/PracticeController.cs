using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PracticeController : MonoBehaviour
{
    PopTarget pop;
    int wait_frame = 0;
    public int clear_number;

    // Start is called before the first frame update
    void Start()
    {
        SceneController.finished = false;
        pop = GameObject.Find("Pop").GetComponent<PopTarget>();
        wait_frame = 0;
    }

	void FixedUpdate() {
		if (!pop.goal) {
			if (!SceneController.finished) {
				++Counter.miss;
				SceneController.finished = true;
			}
			++wait_frame;
			if (wait_frame >= 25) {
				if (Counter.clear + Counter.miss >= clear_number) {
					Counter.clear = 0;
					Counter.miss = 0;
					Counter.elapsed_frame = 0;
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
			SceneController.Quit();
	}
}
