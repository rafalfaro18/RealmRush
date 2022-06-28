using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeployEnemies()); // async.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DeployEnemies(){
        while(true){
            Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}
