using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
	public static int[] seed_array;
	public static int[] practice_seed_array;

	// Start is called before the first frame update
	void Start()
	{
		if(seed_array == null) {
			seed_array = new int[] { 43, 653, 478, 875, 101, 227, 324, 646, 811, 990, 744, 532, 382, 346, 954, 352, 402, 478, 521, 909 };
        }
		if(practice_seed_array == null) {
			practice_seed_array = new int[] { 730, 332, 333 };
        }
		/*if (Counter.elapsed_frame_result == null) {
			Counter.elapsed_frame_result = new List<int>();
			Counter.clear_result = new List<bool>();
		}*/

		for(int i = 0; i < seed_array.Length; ++i) {
			int r = Random.Range(i, seed_array.Length);
			int tmp = seed_array[i];
			seed_array[i] = seed_array[r];
			seed_array[r] = tmp;
        }
		Cursor.visible = true;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0)) {
			/*Counter.clear = 0;
			Counter.miss = 0;
			Counter.elapsed_frame = 0;
			Counter.elapsed_frame_result.Clear();
			Counter.clear_result.Clear();*/
			SceneManager.LoadScene("SelectExperimentNumber");
		}
		if (Input.GetKey(KeyCode.F1)) {
			SceneManager.LoadScene("Result");
		}
		if (Input.GetKey(KeyCode.Escape))
			SceneController.Quit();
	}
}
