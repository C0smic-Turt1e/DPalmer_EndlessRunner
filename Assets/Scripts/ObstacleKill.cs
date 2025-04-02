using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleKill : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x <= -25)
        {
            Destroy(this.gameObject);
        }

    }//end Update()

}//end ObstacleKill
