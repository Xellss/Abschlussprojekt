using UnityEngine;
using System.Collections;
using System.Linq;

public class WaveSpawn : MonoBehaviour {

    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private bool spawn;

    private float x;
    private float z;
    private int sideNumber;
    private GameObject newEnemy;
    void Awake()
    {
        spawnPoints = transform.Cast<Transform>().ToArray();
    }

    void Update()
    {
        if (spawn)
        {
            newEnemy = (GameObject)Instantiate(enemyPrefab, spawnPosition(), Quaternion.identity);
        }
    }

    Vector3 spawnPosition( )
    {
        sideNumber = Random.Range(1, 5);
        print(sideNumber);
        switch (sideNumber)
        {
            case 1:
                return new Vector3(Random.Range(spawnPoints[0].position.x,spawnPoints[1].position.x),transform.position.y,spawnPoints[0].position.z);
            case 2:
                return new Vector3(Random.Range(spawnPoints[2].position.x, spawnPoints[3].position.x), transform.position.y, spawnPoints[2].position.z);
            case 3:
                return new Vector3(spawnPoints[0].position.x, transform.position.y, Random.Range(spawnPoints[0].position.z, spawnPoints[3].position.z));
            case 4:
                return new Vector3(spawnPoints[1].position.x, transform.position.y, Random.Range(spawnPoints[1].position.z, spawnPoints[2].position.z));
        }
        return spawnPoints[0].position;
    }
}
