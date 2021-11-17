using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectFast : MonoBehaviour
{
	public void OnClick() {
		PopTarget.target_speed = 450;
		SceneManager.LoadScene("SelectSticky");
	}
}
