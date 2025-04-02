using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    /*private Ray2D ray;
    private GameObject collidingWith;
    private RaycastHit rayHit;
    private LayerMask ground = LayerMask.GetMask("Ground");


    private void Start()
    {

        ray.origin = this.GetComponent<BoxCollider2D>().transform.position;
        ray.direction = Vector2.up;

    }//end Start()



    private void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up), Color.yellow);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector2.up), out rayHit, Mathf.Infinity, ground))
        {
            collidingWith = rayHit.collider.gameObject;
            collidingWith.GetComponent<Collider>().enabled = false;
        } else
        {
            collidingWith.GetComponent<Collider>().enabled = true;
        }

    }//end Update()*/



    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.transform.tag == "Obstacle")
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
        } else
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
        }

        if (collision.GetComponent<Collectible>() == true)
        {
            collision.GetComponent<Collectible>().Collected();
        }

    }//end OnTriggerEnter2D()



}//end PlayerCollisions
