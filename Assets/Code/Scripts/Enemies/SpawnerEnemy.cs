using System.Collections;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [Header("Spawners")]
    [SerializeField] private GameObject[] spawnersX;
    [SerializeField] private GameObject[] spawnersY;

    [Header("Enemies")]
    [SerializeField] private GameObject enemyX;
    [SerializeField] private GameObject enemyY;

    [SerializeField] private float coolDown = 1.75f;

    public bool IsGameOver { get; private set; }
    public bool IsWaveEnded { get; private set; }

    private void Awake()
    {
        IsGameOver = false;
        IsWaveEnded = false;
    }

    private void Start() => StartCoroutine(CreateEnemy());

    private IEnumerator CreateEnemy()
    {
        while (!IsGameOver && !IsWaveEnded)
        {
            yield return new WaitForSeconds(coolDown);

            int enemyType = CreateRandom(0, 2); // 0 = enemyX, 1 = enemyY
            GameObject enemyToSpawn = (enemyType == 0) ? enemyX : enemyY;

            if (enemyType == 0 && spawnersX.Length > 0)
            {
                SpawnEnemy(enemyToSpawn, spawnersX, false);
            }
            else if (enemyType == 1 && spawnersY.Length > 0)
            {
                SpawnEnemy(enemyToSpawn, spawnersY, true);
            }
        }
    }

    //private void SpawnEnemy(GameObject enemy, GameObject[] spawners)
    //{
    //    int spawnIndex = CreateRandom(0, spawners.Length);
    //    Instantiate(enemy, spawners[spawnIndex].transform.position, Quaternion.identity);
    //}

    private void SpawnEnemy(GameObject enemy, GameObject[] spawners, bool IsVertical)
    {
        int spawnIndex = CreateRandom(0, spawners.Length);
        GameObject spawnedEnemy = Instantiate(enemy, spawners[spawnIndex].transform.position, Quaternion.identity);
        spawnedEnemy.transform.SetParent(null);
        Debug.Log("Spawnato nemico: " + spawnedEnemy.name + " in posizione " + spawnedEnemy.transform.position);

        EnemyMovment enemyMovement = spawnedEnemy.GetComponent<EnemyMovment>();
        if (enemyMovement != null && IsVertical)
        {
            enemyMovement.SetNewDirection(spawnIndex % 2 != 0 ? Vector3.up : Vector3.down);
        }
    }

    private int CreateRandom(int minInclusive, int maxExclusive)
    {
        return UnityEngine.Random.Range(minInclusive, maxExclusive);
    }
}
