using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public int count = 3;
    public float step_time = 1.0f;
    int frame = 0;

    // Start is called before the first frame update
    void Start()
    {
        frame = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ++frame;
        if(frame % (int)(50 * step_time) == 0) {
            --count;
            if(count <= 0) {
                SceneManager.LoadScene("Main");
            }
        }
        gameObject.GetComponent<UnityEngine.UI.Text>().text = $"{count}";
    }
}
