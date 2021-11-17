using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectNormal : MonoBehaviour
{
	public void OnClick() {
		CursorBehavior.is_sticky = false;
		SceneManager.LoadScene("Explanation_1");
	}
}
