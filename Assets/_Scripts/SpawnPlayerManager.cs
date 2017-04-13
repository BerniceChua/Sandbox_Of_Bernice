using UnityEngine;

public class SpawnPlayerManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject m_player;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    private void Awake() {
        Spawn();
    }

    void Start ()
    {
        //InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }

    // old, non-pooling version
    void Spawn ()
    {
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        Instantiate (m_player, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

    //void Spawn() {

    //    if (playerHealth.currentHealth <= 0f) {
    //        return;
    //    }

    //    int spawnPointIndex = Random.Range(0, spawnPoints.Length);


    //    GameObject obj = ObjectPoolerScript.current.GetPooledGameObject();

    //    if (obj == null) return;

    //    obj.transform.position = transform.position;
    //    obj.transform.rotation = transform.rotation;
    //    obj.SetActive(true);
    //}
}
