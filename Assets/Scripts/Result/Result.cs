using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<UnityEngine.UI.Text>().text = $"Clear {Counter.clear} / Miss {Counter.miss}\n\nElapsed Time: {Counter.elapsed_frame * 0.02f}";
        if (Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene("Title");
        }
    }
}
