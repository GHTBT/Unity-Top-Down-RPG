using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject smallSlimePrefab;
    [SerializeField]
    private GameObject bigSlimePrefab;
    [SerializeField]
    private float slimeInterval = 5f;
    [SerializeField]
    private float bigSlimeInterval = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnEnemy(slimeInterval, smallSlimePrefab));
        StartCoroutine(spawnEnemy(bigSlimeInterval, bigSlimePrefab));
    }
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy,new Vector3(Random.Range(-5f,5f), Random.Range(-6f,6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
