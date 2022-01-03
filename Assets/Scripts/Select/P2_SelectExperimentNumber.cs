using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P2_SelectExperimentNumber : MonoBehaviour
{
	public void Select1() {
		PopTarget.target_speed = Conditions.SlowSpeed;
		PopTarget.target_size = Conditions.BigSize;
		CursorBehavior.is_sticky = true;
		SceneManager.LoadScene("Explanation_1");
	}
	public void Select2() {
		PopTarget.target_speed = Conditions.SlowSpeed;
		PopTarget.target_size = Conditions.BigSize;
		CursorBehavior.is_sticky = false;
		SceneManager.LoadScene("Explanation_1");
	}
}
