using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSmall : MonoBehaviour
{
    public void OnClick() {
        PopTarget.target_size = 50;
        SceneManager.LoadScene("SelectSpeed");
    }
}
