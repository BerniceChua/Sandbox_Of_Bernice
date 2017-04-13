using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// to serialize data in C#, you need these 3 libraries: "System", "System.IO", & "System.Runtime.Serialization.Formatters.Binary".
using System;
using System.Runtime.Serialization.Formatters.Binary; // players cannot modify this unless they know binary, so more secure.
using System.IO;

// an example of a Singleton design pattern
public class DontDestroyOnLoadGameControl : MonoBehaviour {
    public static DontDestroyOnLoadGameControl control;

    public float m_health;
    public float m_experience;

	// We use Awake() instead of Start() for initialization because Awake() loads before anything else is ready.  Start() only loads if everything is ready.
	void Awake () {
		if (control == null) {
            DontDestroyOnLoad(gameObject);
            control = this;
        } else if (control != this) {
            Destroy(gameObject);
        }

	}

    private void OnGUI() {
        GUI.Label(new Rect(10, 10, 100, 30), "Health: " + m_health);
        GUI.Label(new Rect(10, 40, 150, 30), "Experience: " + m_experience);
    }

    // writes data to a file, this works on ALL platforms except for WebGL.
    public void Save() {
        // step 1: create a file
        // step 2: push data to a file

        BinaryFormatter binFormSave = new BinaryFormatter();

        // saves to "persistent data path".  "Application.persistentDataPath" is a string of the path.
        FileStream fileToSave = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        // tells what data we want to write into the file.
        // now we will instantiate the PlayerData class that we made below.
        PlayerData dataToSave = new PlayerData();
        dataToSave.health = m_health;
        dataToSave.experience = m_experience;

        // now we will actually WRITE to a file.
        // ".Serialize()" means write to a file.
        binFormSave.Serialize(fileToSave, dataToSave);
        fileToSave.Close();
    }


    // reads from a file
    public void Load() {
        // step 1: make sure that the load file exists.
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) {
            BinaryFormatter binFormLoad = new BinaryFormatter();
            // FileStream fileToLoad = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open); // for loading a file, Open() is obsolete from Unity v.4.
            FileStream fileToLoad = File.OpenRead(Application.persistentDataPath + "/playerInfo.dat"); // no need for FileMode to load a file with OpenRead().

            // need a container to pull this data out.  "Just us pulling it back out of the file."
            PlayerData dataToLoad = (PlayerData)binFormLoad.Deserialize(fileToLoad);
            // when Deserializing, we're effectively creating a generic object.  There's no real way to know what it is, so
            // we need to cast the generic object.

            m_health = dataToLoad.health;
            m_experience = dataToLoad.experience;
        }
    }

}

[Serializable] // this tag tells Unity that everything in this class can be serializable (meaning can easily fit into a binary format). Now the class is a data container that allows us to write these variables to a file.
class PlayerData {
    public float health;
    public float experience;
}