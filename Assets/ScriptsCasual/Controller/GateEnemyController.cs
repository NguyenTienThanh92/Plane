using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateEnemyController : MonoBehaviour
{
    public GameObject[] pointEnemy;
    public GameObject[] enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, enemy.Length);
            int randomIndex1 = Random.Range(0, pointEnemy.Length);
            GameObject instantiateObject = Instantiate(enemy[randomIndex], pointEnemy[randomIndex1].transform.position, Quaternion.identity) as GameObject;
            yield return new WaitForSeconds(1.5f);
        }
    }
}
