using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ForegroundMove : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    private Rigidbody2D foregroundRB;
    [SerializeField] private SpriteRenderer spriteRend;
    public float spriteLength;
    public float distanceMoved;
    private float spriteStartPos;

    void Start()
    {

        spriteStartPos = transform.position.x;
        spriteLength = spriteRend.bounds.size.x;

        foregroundRB = GetComponent<Rigidbody2D>();
        foregroundRB.velocity = Vector2.left * moveSpeed;

    }//end Start()



    private void Update()
    {

        distanceMoved = (spriteStartPos - transform.position.x);

        if (distanceMoved >= spriteLength)
        {

            transform.position = new Vector3(spriteStartPos, transform.position.y, transform.position.z);
            distanceMoved = 0;

        }

    }//end Update()

    public void SpeedUp(float newSpeed)
    {
        foregroundRB.velocity = Vector2.left * newSpeed;
    }



}//end ForegroundMove
