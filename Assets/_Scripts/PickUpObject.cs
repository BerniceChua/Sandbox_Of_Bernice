using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour {
    [SerializeField] float m_distance = 1.0f;
    [SerializeField] float m_smooth = 4.5f;

    private Camera m_fpsCam;

    GameObject m_carriedObject;
    bool m_carrying;
    GameObject pickupable;

    // Use this for initialization
    void Start () {
        m_fpsCam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update() {
        OutlineTheSelected(GetMouseHoverObject(5));

        if (m_carrying) {
            Debug.Log("m_carrying is true");
            Carry(m_carriedObject);

            CheckIfDropObject();
        } else {
            Debug.Log("m_carrying is false");
            PickUp();
        }
    }


    //if (m_carriedObject != null) {
    //        Vector3 newPosition = transform.position + Camera.main.transform.forward * m_distance;
    //m_carriedObject.transform.position = newPosition;
    //    }

    GameObject GetMouseHoverObject(float range) {
        RaycastHit hit;
        //Vector3 currentPosition = transform.position;
        //Vector3 target = currentPosition + Camera.main.transform.forward;
        Vector3 rayOrigin = m_fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        if (Physics.Raycast(rayOrigin, m_fpsCam.transform.forward, out hit))
            return hit.collider.gameObject;

        return null;
    }

    bool CanGrab(GameObject candidate) {
        return candidate.GetComponent<Rigidbody>() != null;
    }

    void Carry(GameObject grabObj) {
        //Debug.Log("inside Carry(GameObject grabObj) {}");

        grabObj.transform.parent = this.transform;

        grabObj.transform.position = m_fpsCam.transform.position + m_fpsCam.transform.forward * m_distance;
        // in the tutorial video, this was replaced by:
        //grabObj.transform.position = Vector3.Lerp(grabObj.transform.position, m_fpsCam.transform.position + m_fpsCam.transform.forward * m_distance, Time.deltaTime * m_smooth);
        // but we don't need it, since I added this line: "grabObj.transform.parent = this.transform;" 
        // it ends up bobbing like a balloon, unless that's the effect that you're going for.
    }

    void PickUp() {
        Debug.Log("inside PickUp() {}");
        if (Input.GetKeyDown(KeyCode.E)) {
            RaycastHit hit;

            float x = Screen.width / 2.0f;
            float y = Screen.height / 2.0f;
            Ray ray = m_fpsCam.ScreenPointToRay(new Vector3(x, y, 0.0f));

            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.CompareTag("Pickupable")) {
                    pickupable = hit.collider.gameObject;

                    //if (pickupable != null) {
                    //    m_carrying = true;
                    //    m_carriedObject = pickupable.gameObject;
                    //}

                }

                if (pickupable != null) {
                    m_carrying = true;
                    m_carriedObject = pickupable.gameObject;
                    pickupable.GetComponent<Rigidbody>().isKinematic = true;
                }

            }
        }
    }

    void CheckIfDropObject() {
        if (Input.GetKeyDown(KeyCode.E)) {
            m_carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            m_carriedObject.transform.parent = null;
            m_carriedObject = null;
            m_carrying = false;
        }
    }

    void OutlineTheSelected(GameObject selected) {
        //Mesh mesh = selected.GetComponent<Mesh>();
        //Transform position = selected.transform.position;

        //Graphics.DrawMesh(mesh, position, selected.transform.rotation);
    }

}