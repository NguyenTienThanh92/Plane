using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateItemController : MonoBehaviour
{
    public GameObject[] pointItem;
    public GameObject[] item; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ItemSpawn());
    }
  
    IEnumerator ItemSpawn()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, item.Length);
            int randomIndex1 = Random.Range(0, pointItem.Length);
            GameObject instantiateObject = Instantiate(item[randomIndex], pointItem[randomIndex1].transform.position, Quaternion.identity) as GameObject;
            yield return new WaitForSeconds(5f);

        }
    }
}
