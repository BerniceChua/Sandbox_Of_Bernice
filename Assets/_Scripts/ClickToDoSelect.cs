using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToDoSelect : MonoBehaviour {
    public int m_value;

    // Use this for initialization
    void Start () {
        m_value = 0;
	}
	
    void OnMouseDown() {
        //RaycastHit hit;
        Debug.Log("Click!");

        if (Input.GetMouseButtonDown(0)) {  // zero is left click on the mouse.
            Debug.Log("Bang!");
            m_value++;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
