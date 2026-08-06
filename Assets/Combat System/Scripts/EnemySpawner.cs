using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    private const int maxEnemies = 3;
    private int indexCount;
    private int[] tileHasMob = new int[maxEnemies] { 0, 0, 0 };
    [SerializeField] private GameObject[] enemyList = new GameObject[maxEnemies];
    [SerializeField] private Transform startPosition;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = startPosition.position;
        foreach (GameObject enemy in enemyList)
        {
            Debug.Log("Finding Tile");
            FindSpawnPointRecursive(enemy, 0);
        }
        Destroy(gameObject);
    }
    private void FindSpawnPointRecursive(GameObject mobToSpawn, int index)
    {
        for (int search = index; search < maxEnemies; search++)
        {
            int tileNum = Random.Range(1, 2);
            Debug.Log("Trying Tile " + tileNum);
            if (tileHasMob[search] == tileNum)
            {
                Debug.Log("Has Mob");
                continue;
            }
            else
            {
                GameObject newTile = GameObject.Find("TileEnemy" + tileNum);
                Transform spawnPosition = newTile.transform.GetChild(1).transform;
                Instantiate(mobToSpawn, spawnPosition.position, gameObject.transform.rotation);
                if(tileHasMob[search]!= 0)
                {
                    
                }
                return;
            }
        }
    }
}
