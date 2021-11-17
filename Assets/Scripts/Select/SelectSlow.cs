using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSlow : MonoBehaviour
{
	public void OnClick() {
		PopTarget.target_speed = 300;
		SceneManager.LoadScene("SelectSticky");
	}
}
