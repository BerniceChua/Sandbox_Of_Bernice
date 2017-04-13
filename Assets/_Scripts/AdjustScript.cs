using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustScript : MonoBehaviour {

	private void OnGUI() {
        if (GUI.Button(new Rect(10, 100, 100, 30), "Health up")) {
            DontDestroyOnLoadGameControl.control.m_health += 10;
        }

        if (GUI.Button(new Rect(10, 140, 100, 30), "Health down")) {
            DontDestroyOnLoadGameControl.control.m_health -= 10;
        }

        if (GUI.Button(new Rect(10, 180, 100, 30), "Experience up")) {
            DontDestroyOnLoadGameControl.control.m_experience += 10;
        }

        if (GUI.Button(new Rect(10, 220, 100, 30), "Experience down")) {
            DontDestroyOnLoadGameControl.control.m_experience -= 10;
        }

        if (GUI.Button(new Rect(10, 260, 100, 30), "Save")) {
            DontDestroyOnLoadGameControl.control.Save();
        }

        if (GUI.Button(new Rect(10, 300, 100, 30), "Load")) {
            DontDestroyOnLoadGameControl.control.Load();
        }

    }
}
