using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupTrigger2 : MonoBehaviour {
    [SerializeField] Texture m_popupObject;

    bool m_display;

    // Use this for initialization
    void Start () {
        //m_popupObject.SetActiveRecursively(false);
        // above code is obsolete, therefore:
        m_display = false;
    }
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            //m_popupObject.SetActiveRecursively(true);
            // above code is obsolete, therefore:
            m_display = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            //m_popupObject.SetActiveRecursively(false);
            // above code is obsolete, therefore:
            m_display = false;
        }
    }

    private void OnGUI() {
        if (m_display)
            GUI.DrawTexture(new Rect(Screen.width / 4.5f, Screen.height / 4, 1024, 512), m_popupObject);
    }

}