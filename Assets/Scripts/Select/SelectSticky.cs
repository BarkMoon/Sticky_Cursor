using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSticky : MonoBehaviour
{
	public void OnClick() {
		CursorBehavior.is_sticky = true;
		SceneManager.LoadScene("Explanation_1");
	}
}
