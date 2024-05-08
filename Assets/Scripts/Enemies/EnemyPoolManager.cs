using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolManager : MonoBehaviour
{

    public static EnemyPoolManager Instance;

    public GameObject enemyPrefab;

    public int poolsize = 10;

    private Queue<GameObject> enemyPool = new Queue<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        
        Instance = this;
        InitializePool();
    }

    // Update is called once per frame
    private void InitializePool(){
        for (int i = 0; i < poolsize; i++){
            GameObject newEnemy = Instantiate(enemyPrefab);
            newEnemy.SetActive(false);
            enemyPool.Enqueue(newEnemy);
        }
    }

    public GameObject GetEnemy(){

        if(enemyPool.Count > 0){

            GameObject enemy = enemyPool.Dequeue();
            enemy.SetActive(true);
            return enemy;
        }
        else{
            GameObject newEnemy = Instantiate(enemyPrefab);
            newEnemy.SetActive(true);
            return newEnemy;
        }
    }

    public void ReturnEnemy(GameObject enemy){

        enemy.SetActive(false);
        enemyPool.Enqueue(enemy);
    }
}
