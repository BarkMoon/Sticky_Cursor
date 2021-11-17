using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public int count = 3;
    public float step_time = 1.0f;
    GameObject cursor;
    public static Vector3 cursor_position;
    int frame = 0;

    // Start is called before the first frame update
    void Start()
    {
        cursor = GameObject.Find("Cursor");
        frame = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ++frame;
        if(frame % (int)(50 * step_time) == 0) {
            --count;
            if(count <= 0) {
                cursor_position = cursor.transform.position;
                if (SceneController.is_in_practice)
                    SceneManager.LoadScene("Practice");
                else
                    SceneManager.LoadScene("Main");
            }
        }
        gameObject.GetComponent<UnityEngine.UI.Text>().text = $"{count}";
    }
    void Update() {
        if (Input.GetKey(KeyCode.Escape))
            SceneController.Quit();
    }
}
