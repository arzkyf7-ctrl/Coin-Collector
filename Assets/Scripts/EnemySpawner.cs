using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombie;
    [SerializeField] private GameObject coneZombie;
    [SerializeField] private GameObject bucketZombie;
    [SerializeField] private float zombieInterval = 2f;
    [SerializeField] private float coneZombieInterval = 4f;
    [SerializeField] private float bucketZombieInterval = 6f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnZombie(zombieInterval, zombie));
        StartCoroutine(spawnZombie(coneZombieInterval, coneZombie));
        StartCoroutine(spawnZombie(bucketZombieInterval, bucketZombie));
    }
    private IEnumerator spawnZombie(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnZombie(interval, enemy));
    }
}
