using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CalibrationCursor : MonoBehaviour
{
    public Sprite normal, push;
    SpriteRenderer sprite_renderer;
    Vector3 last_mouse_position;
    bool touching;
    // Start is called before the first frame update
    void Start()
    {
        sprite_renderer = gameObject.GetComponent<SpriteRenderer>();
        sprite_renderer.sprite = normal;

        Cursor.visible = false;
        transform.position = Input.mousePosition + new Vector3(-600, -450, 0);
        last_mouse_position = Input.mousePosition;
        touching = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition + new Vector3(-600, -450, 0);
        if(Vector3.Magnitude(transform.position) <= 25) {
            sprite_renderer.sprite = push;
            touching = true;
        }
        else {
            sprite_renderer.sprite = normal;
            touching = false;
        }
        if(Input.GetMouseButtonDown(0) && touching) {
            SceneManager.LoadScene("Wait");
        }
        if (Input.GetKey(KeyCode.Escape))
            SceneController.Quit();
    }
}
