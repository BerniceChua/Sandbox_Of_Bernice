using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupTrigger : MonoBehaviour {
    [SerializeField] GameObject m_popupObject;

    // Use this for initialization
    void Start () {
        //m_popupObject.SetActiveRecursively(false);
        // above code is obsolete, therefore:
        m_popupObject.SetActive(false);
    }
	
	// Update is called once per frame
	void OnTriggerEnter() {
        //m_popupObject.SetActiveRecursively(true);
        // above code is obsolete, therefore:
        m_popupObject.SetActive(true);
    }

    void OnTriggerExit() {
        //m_popupObject.SetActiveRecursively(false);
        // above code is obsolete, therefore:
        m_popupObject.SetActive(false);
    }

}