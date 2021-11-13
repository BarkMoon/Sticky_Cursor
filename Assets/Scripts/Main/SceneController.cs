using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    PopTarget pop;
    int wait_frame = 0;
    public static bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        finished = false;
        pop = GameObject.Find("Pop").GetComponent<PopTarget>();
        wait_frame = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!pop.goal) {
            if (!finished)
                ++Counter.miss;
            ++wait_frame;
            if (wait_frame >= 25) {
                if(Counter.clear >= 20) {
                    SceneManager.LoadScene("Result");
                }
                else {
                    SceneManager.LoadScene("Wait");
                }
            }
        }
    }
}
