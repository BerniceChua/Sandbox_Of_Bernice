using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOverDisplayUI : MonoBehaviour {
    public string m_myString;
    public Text m_myText;
    public float m_fadeTime;
    public bool m_displayInfo;

	// Use this for initialization
	void Start () {
        //m_displayInfo = false;
        m_myText = GameObject.Find("Text").GetComponent<Text>();
        m_myText.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
        FadeText();

        if (Input.GetKeyDown(KeyCode.Escape)) {
            //screen.lockcursor = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnMouseOver() {
        m_displayInfo = true;
    }

    private void OnMouseExit() {
        m_displayInfo = false;
    }

    void FadeText() {
        if (m_displayInfo) {
            m_myText.text = m_myString;
            m_myText.color = Color.Lerp(m_myText.color, Color.black, m_fadeTime * Time.deltaTime);
        } else {
            m_myText.color = Color.Lerp(m_myText.color, Color.clear, m_fadeTime * Time.deltaTime);
        }
    }

}