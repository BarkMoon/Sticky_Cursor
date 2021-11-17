using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explanation_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            SceneController.is_in_practice = true;
            Counter.clear = 0;
            Counter.miss = 0;
            Counter.elapsed_frame = 0;
            SceneManager.LoadScene("Calibration");
        }
        if (Input.GetKey(KeyCode.Escape))
            SceneController.Quit();
    }
}
