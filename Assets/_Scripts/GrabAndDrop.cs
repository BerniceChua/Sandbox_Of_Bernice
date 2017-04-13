using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndDrop : MonoBehaviour {
    private Camera m_fpsCam;

    GameObject m_grabbedObject;
    float m_sizeOfGrabbedObject;

    // Use this for initialization
    void Start () {
        m_fpsCam = GetComponentInChildren<Camera>();
    }
	
    GameObject GetMouseHoverObject(float range) {
        RaycastHit hit;
        //Vector3 currentPosition = transform.position;
        //Vector3 target = currentPosition + Camera.main.transform.forward;
        Vector3 rayOrigin = m_fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        if (Physics.Raycast(rayOrigin, m_fpsCam.transform.forward, out hit))
            return hit.collider.gameObject;

        return null;
    }

    //private void OnMouseDown() {

    //}

    //private void OnMouseUp() {

    //}

    bool CanGrab(GameObject candidate) {
        return candidate.GetComponent<Rigidbody>() != null;
    }

    void TryGrabObject(GameObject grabObj) {
        if (grabObj == null || !CanGrab(grabObj))
            return;

        m_grabbedObject = grabObj;
        m_sizeOfGrabbedObject = grabObj.GetComponent<Renderer>().bounds.size.magnitude;
    }

    void DropObject() {
        if (m_grabbedObject == null)
            return;

        if (m_grabbedObject.GetComponent<Rigidbody>() != null)
            m_grabbedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        m_grabbedObject = null;
    }

    // Update is called once per frame
    void Update() {
        Debug.Log(GetMouseHoverObject(5));

        if (Input.GetMouseButtonDown(0)) {
            if (m_grabbedObject = null)
                TryGrabObject(GetMouseHoverObject(5));
            else
                DropObject();
        }

        if (m_grabbedObject != null) {
            Vector3 newPosition = transform.position + Camera.main.transform.forward * m_sizeOfGrabbedObject;
            m_grabbedObject.transform.position = newPosition;
        }
    }

}