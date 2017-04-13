using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TraverseScreenScript : MonoBehaviour {
    [SerializeField] int m_sceneToLoad;

    private int m_sceneID;

    private void Awake() {
        m_sceneID = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void OnGUI () {
        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height - 80, 100, 30), "Current Scene: " + m_sceneID);
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height - 50, 100, 40), "Load Scene " + m_sceneToLoad)) {
            SceneManager.LoadScene(m_sceneToLoad-1);
        }
	}

}
