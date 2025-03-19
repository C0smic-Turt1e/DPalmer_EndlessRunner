using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private float jumpTime = 0.3f;
    [SerializeField] private Transform feetPos;
    [SerializeField] private LayerMask groundLayer; //what layer of objects counts as the ground;

    private bool isGrounded;
    private bool isJumping;
    private float jumpTimer;



    private void Awake()
    {
        
        playerRB = GetComponent<Rigidbody2D>();

    }//end Awake()



    // Start is called before the first frame update
    void Start()
    {

    }//end Start()



    // Update is called once per frame
    void Update()
    {

        if (Physics2D.OverlapCircle(feetPos.position, 0.25f, groundLayer) == true)
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }



        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            playerRB.velocity = Vector2.up * jumpForce;
            isJumping = true;
        }



        if (isJumping == true && Input.GetButton("Jump")) 
        {

            if (jumpTimer < jumpTime)
            {
                playerRB.velocity = Vector2.up * jumpForce;
                jumpTimer += Time.deltaTime;
            } else
            {
                isJumping = false;
            }

        }



        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpTimer = 0;
        }

    }//end Update()



}//end PlayerMovement
