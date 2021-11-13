using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehavior : MonoBehaviour
{
    public bool is_sticky = false;
    PopTarget pop;
    int target_size;
    Counter counter;
    GameObject finish_text;
    Vector3 last_mouse_position;

    // Start is called before the first frame update
    void Start()
    {
        pop = GameObject.Find("Pop").GetComponent<PopTarget>();
        target_size = pop.target_size;
        counter = GameObject.Find("Counter").GetComponent<Counter>();
        finish_text = GameObject.Find("FinishText");
        finish_text.SetActive(false);

        Cursor.visible = false;
        transform.position = Input.mousePosition + new Vector3(-600, -450, 0);
        last_mouse_position = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_sticky) {
            Vector3 movement = Input.mousePosition - last_mouse_position;
            last_mouse_position = Input.mousePosition;
            transform.position += movement;

            float speed = 0, move_direction = 0;
            float distance_d, distance_g;
            foreach (TargetBehavior dummy in pop.dummies) {
                if (dummy) {
                    distance_d = Vector3.Distance(transform.position, dummy.transform.position);
                    if (distance_d <= target_size / 2) {
                        speed = dummy.speed;
                        move_direction = dummy.move_direction;
                    }
                }
            }
            distance_g = Vector3.Distance(transform.position, pop.goal.transform.position);
            if (distance_g <= target_size / 2) {
                speed = pop.goal.speed;
                move_direction = pop.goal.move_direction;
            }
            Vector3 pos = transform.position;
            pos.x += speed * Mathf.Cos(move_direction);
            pos.y += speed * Mathf.Sin(move_direction);
            this.transform.position = pos;
        }
        else
            transform.position = Input.mousePosition + new Vector3(-600, -450, 0);

        if (!SceneController.finished && Input.GetMouseButtonDown(0) && pop.goal) {
            int failure = 0;
            float distance_d, distance_g;
            foreach (TargetBehavior dummy in pop.dummies) {
                if (dummy) {
                    distance_d = Vector3.Distance(transform.position, dummy.transform.position);
                    if (distance_d <= target_size / 2) {
                        ++failure;
                        Debug.Log(distance_d);
                    }
                }
            }
            distance_g = Vector3.Distance(transform.position, pop.goal.transform.position);
            if (distance_g > target_size / 2) {
                ++failure;
            }
            if(failure == 0) {      // ê¨å˜
                ++Counter.clear;
                pop.goal.GetComponent<SpriteRenderer>().color = new Color(0, 1.0f, 0);
                finish_text.GetComponent<UnityEngine.UI.Text>().text = "Success!";
                finish_text.SetActive(true);
            }
            else {
                ++Counter.miss;
                finish_text.GetComponent<UnityEngine.UI.Text>().text = "Failed";
                finish_text.SetActive(true);
            }
            SceneController.finished = true;
        }
    }
}
