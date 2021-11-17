using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectBig : MonoBehaviour
{
    public void OnClick() {
        PopTarget.target_size = 100;
        SceneManager.LoadScene("SelectSpeed");
    }
}
