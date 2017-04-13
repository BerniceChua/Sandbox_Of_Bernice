using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {
    [SerializeField] float m_rotationSpeed = 20;

    private void OnMouseDrag() {
        float rotationX = Input.GetAxis("Mouse X") * m_rotationSpeed * Mathf.Deg2Rad;
        float rotationY = Input.GetAxis("Mouse Y") * m_rotationSpeed * Mathf.Deg2Rad;

        //transform.RotateAround(Vector3.up, -rotationX);
        //transform.RotateAround(Vector3.right, rotationY);
        // the above 2 were obsolete
        transform.Rotate(Vector3.up, -rotationX);
        transform.Rotate(Vector3.right, rotationY);
        // this is the not-so-optimal version of rotate, because it causes the rotating object to gimbal-lock.
        // better version is the Quaternion rotation.
    }
    
}
