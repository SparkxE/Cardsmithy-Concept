using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    private const int maxEnemies = 3;
    private int[] tileHasMob = new int[maxEnemies] { 0, 0, 0 };
    [SerializeField] private GameObject[] enemyList = new GameObject[maxEnemies];
    [SerializeField] private Transform startPosition;

    // Start is called before the first frame update
    void Start()
    {
        int index = 0;
        gameObject.transform.position = startPosition.position;
        foreach (GameObject enemy in enemyList)
        {
            Debug.Log("Finding Tile");
            SpawnEnemy(enemy, index);
            index++;
        }
        Destroy(gameObject);
    }
    private void SpawnEnemy(GameObject mobToSpawn, int index)
    {
        int spawnPoint = GetRandomTile(); //get a random tileID that doesn't match existing entries in tileHasMob[]
        GameObject newTile = GameObject.Find("TileEnemy" + spawnPoint);
        Transform spawnPosition = newTile.transform.GetChild(1).transform;
        Instantiate(mobToSpawn, spawnPosition.position, gameObject.transform.rotation);
        tileHasMob[index] = spawnPoint; //add the used tileID to tileHasMob[] at the index matching the spawned mob's
    }

    private int GetRandomTile()
    {
        int tileID = Random.Range(1, 9);
        for (int index = 0; index < tileHasMob.Length - 1; index++) //check all but the last index of tileHasMob[] for matching values
        {
            if (tileHasMob[index] == tileID)
            {
                tileID = GetRandomTile();   //recursively get a new random number until a non-used value is found
            }
        }
        return tileID;
    }
}
