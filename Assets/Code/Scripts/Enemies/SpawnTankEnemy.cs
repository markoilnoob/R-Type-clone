using System.Collections;
using UnityEngine;

public class SpawnTankEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyTank;
    [SerializeField] private GameObject[] pointsToGo;

    private void Start() => StartCoroutine(SpawnEnemies());

    private IEnumerator SpawnEnemies()
    {
        //Generate x enemies
        for (int i = 0; i < pointsToGo.Length; i++)
        {
            Instantiate(enemyTank, pointsToGo[i].transform.position, Quaternion.identity);
        }

        yield return new WaitForSeconds(1);

    }
}

//Manage enemies
//for (int i = 0; i < enemiesTanks.Length; i++)
//{
//    if (enemiesTanks[i] == null) continue;
//    var app = enemiesTanks[i].gameObject.GetComponent<CircularMovment>();
//    if (app != null)
//    {

//    }
//}

