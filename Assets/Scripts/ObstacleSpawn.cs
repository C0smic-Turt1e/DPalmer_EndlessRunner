using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{

    [SerializeField] private List<GameObject> obstaclePrefabs = new List<GameObject>();
    
    public float obstacleSpeed = 5f;

    public float spawnTimeMin = 2f;
    public float spawnTimeMax = 5f;
    private float spawnTimer;
    public float obstacleSpawnTime = 2f;
    

    [SerializeField] private ObstacleKill obstacleKill;



    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.P))
        {
            Spawn();
        }

            SpawnLoop();

    }//end Update()



    private void SpawnLoop()
    {

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= obstacleSpawnTime)
        {

            Spawn();

            obstacleSpawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            spawnTimer = 0;


        }

    }//end SpawnLoop()



    private void Spawn()
    {

        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];

        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);
        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        spawnedObstacle.AddComponent<ObstacleKill>();

        obstacleRB.velocity = Vector2.left * obstacleSpeed;

    }//end Spawn()



}//end ObstacleSpawn()
