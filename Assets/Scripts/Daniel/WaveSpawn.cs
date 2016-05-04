using System.Linq;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private bool spawn;

    [SerializeField]
    private int enemyCounter;

    private Transform[] spawnPoints;
    private int sideNumber;
    private GameObject newEnemy;

    private void Awake()
    {
        spawnPoints = transform.Cast<Transform>().ToArray();
    }

    private void Update()
    {
        if (spawn)
        {
            spawn = false;
            spawnEnemy();
        }
    }

    private void spawnEnemy()
    {
        for (int i = 0; i < enemyCounter; i++)
        {
            newEnemy = (GameObject)Instantiate(enemyPrefab, spawnPosition(), Quaternion.identity);
        }
    }

    private Vector3 spawnPosition()
    {
        sideNumber = Random.Range(1, 5);
        print(sideNumber);
        switch (sideNumber)
        {
            case 1:
                return new Vector3(Random.Range(spawnPoints[0].position.x, spawnPoints[1].position.x), transform.position.y, spawnPoints[0].position.z);

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