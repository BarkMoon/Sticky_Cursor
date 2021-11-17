using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationMouseText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<UnityEngine.UI.Text>().text = $"mouse position: ({Input.mousePosition.x - 600}, {Input.mousePosition.y - 450})";
    }
}
