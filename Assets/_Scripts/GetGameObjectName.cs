using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGameObjectName : MonoBehaviour {
    [SerializeField] Camera m_cam;
    [SerializeField] Transform m_nameDisplay;

    string m_objectName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = m_cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            m_objectName = hit.transform.name.ToString();
        } else {
            m_objectName = "";
        }

        m_nameDisplay.GetComponent<GUIText>().text = m_objectName;
	}
}
