using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CursorTypeText : MonoBehaviour
{
    StringBuilder sb;

    // Start is called before the first frame update
    void Start()
    {
        sb = new StringBuilder();
        sb.Append("Cursor Type: ");
        string stk = (CursorBehavior.is_sticky) ? "Sticky" : "Normal";
        sb.Append(stk);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = sb.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
