using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruit : MonoBehaviour {
    [SerializeField] GameObject m_fruit;

    int m_spawnNumber = 8;

	// Use this for initialization
	void Start () {
        Spawn();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Spawn() {
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        float z = this.transform.position.z;

        for (int i = 0; i < m_spawnNumber; i++) {
            Vector3 fruitPosition = new Vector3(x + Random.Range(-1.0f, 1.0f), y + Random.Range(0.0f, 1.0f), z + Random.Range(-1.0f, 1.0f));
            Instantiate(m_fruit, fruitPosition, Quaternion.identity);
        }
    }

}
