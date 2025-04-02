using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollisions : MonoBehaviour
{

    [SerializeField] private BoxCollider2D mainCollider;
    [SerializeField] private BoxCollider2D aboveCollider;
    [SerializeField] private BoxCollider2D belowCollider;

    private void Start()
    {
           mainCollider.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (aboveCollider.IsTouching(collision) == true && belowCollider.IsTouching(collision) == false)
        {
            Debug.Log("Can land!");
            mainCollider.enabled = true;
        } else
        {
            Debug.Log("Cannot land!");
            mainCollider.enabled = false;
        }

    }//end OnTriggerEnter2D(Collider2D)


}//end ObstacleCollisions
