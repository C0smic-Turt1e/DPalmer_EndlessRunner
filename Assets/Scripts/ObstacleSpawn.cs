using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{

    [SerializeField] private GameObject obstacle;
    [SerializeField] private float obstacleSpeed = 3f;




    // Start is called before the first frame update
    void Start()
    {
        


    }//end Start()



    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.P))
        {
            Spawn();
        }

    }//end Update()



    private void SpawnLoop()
    {



    }//end SpawnLoop()



    private void Spawn()
    {

        GameObject spawnedObstacle = Instantiate(obstacle, transform.position, Quaternion.identity);
        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();

        obstacleRB.velocity = Vector2.left * obstacleSpeed;

    }//end Spawn()



}//end ObstacleSpawn()
