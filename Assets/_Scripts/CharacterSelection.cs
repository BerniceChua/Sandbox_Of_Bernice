using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {
    private GameObject[] m_characterList;
    private int m_index;

	// Use this for initialization
	void Start () {
        m_index = PlayerPrefs.GetInt("CharacterSelected");

        m_characterList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++) {
            m_characterList[i] = transform.GetChild(i).gameObject;
            m_characterList[i].SetActive(false);
        }

        if (m_characterList[m_index])
            m_characterList[m_index].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToggleLeft() {
        m_characterList[m_index].SetActive(false);

        m_index--;

        if (m_index < 0)
            m_index = m_characterList.Length - 1;

        m_characterList[m_index].SetActive(true);
    }

    public void ToggleRight() {
        m_characterList[m_index].SetActive(false);

        m_index++;

        if (m_index > m_characterList.Length - 1)
            m_index = 0;

        m_characterList[m_index].SetActive(true);
    }

    public void Confirm() {
        PlayerPrefs.SetInt("CharacterSelected", m_index);

        //if (GameObject.FindGameObjectWithTag("Spawnpoint")) {
        //    Transform spawnPosition = GameObject.FindGameObjectWithTag("Spawnpoint").transform;
        //    m_characterList[m_index].transform.position = spawnPosition.position;
        //}

        m_characterList[m_index].AddComponent<DontDestroyOnLoadGameControl>();

        SceneManager.LoadScene("Creating_Terrain_And_Objects");
    }

}
