using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
	StringBuilder sb;
	
	// Start is called before the first frame update
	void Start()
	{
		Cursor.visible = true;

		sb = new StringBuilder();
		
		/*string spd = (PopTarget.target_speed == Conditions.FastSpeed) ? "Fast/" : "Slow/";
		sb.Append(spd);
		string sz = (PopTarget.target_size == Conditions.BigSize) ? "Big/" : "Small/";
		sb.Append(sz);
		string stk = (CursorBehavior.is_sticky) ? "Sticky" : "Normal";
		sb.Append(stk);
		sb.Append("\n");

		int total_frame = 0;
		foreach(int frame in Counter.elapsed_frame_result) {
			total_frame += frame;
		}*/

		sb.Append($"Clear {Counter.clear} / Miss {Counter.miss}\n\nTotal Time: {Counter.elapsed_frame * 0.02f:F2}");

		/*sb.Append("\n\nElapsed Time\n");
		for (int i = 0; i < Counter.elapsed_frame_result.Count; ++i) {
			sb.Append($"{i:D2}:\t{Title.seed_array[i]:D3}  {Counter.elapsed_frame_result[i] * 0.02:F2}  ");
			string cl = (Counter.clear_result[i]) ? "Clear" : "Miss ";
			sb.Append(cl);
			sb.Append((i % 2 == 0) ? "\t\t" : "\n");
		}*/
		gameObject.GetComponent<UnityEngine.UI.Text>().text = sb.ToString();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
			SceneController.Quit();
	}
}
