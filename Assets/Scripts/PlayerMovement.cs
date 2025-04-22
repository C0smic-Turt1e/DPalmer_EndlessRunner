using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private float jumpTime = 0.3f;
    [SerializeField] private Transform feetPos;
    [SerializeField] private LayerMask groundLayer; //what layer of objects counts as the ground;
    [SerializeField] private LayerMask trickLayer;

    private bool isGrounded;
    private bool isJumping;
    //private bool isBackflipping;
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
            GetComponentInChildren<Animator>().SetTrigger("Stop Jump");
            GetComponentInChildren<Animator>().speed = 1;
        } else
        {
            isGrounded = false;
        }


        //checks for jump tricks or normal jump
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) //backflip
            {

                if (Physics2D.OverlapCircle(this.transform.position, 20f, trickLayer) == true)
                {
                    GameManager.Instance.newPoints += 20f;
                } else 
                {
                    GameManager.Instance.newPoints += 5f;
                }

                    GetComponentInChildren<Animator>().SetTrigger("Backflip");

            } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) //frontflip
            {

                if (Physics2D.OverlapCircle(this.transform.position, 20f, trickLayer) == true)
                {
                    GameManager.Instance.newPoints += 20f;
                }
                else
                {
                    GameManager.Instance.newPoints += 5f;
                }
                GetComponentInChildren<Animator>().SetTrigger("Frontflip");

            } else ///normal jump
            {

                if (Physics2D.OverlapCircle(this.transform.position, 20f, trickLayer) == true)
                {
                    GameManager.Instance.newPoints += 7f;
                }
                else
                {
                    GameManager.Instance.newPoints += 5f;
                }
                GetComponentInChildren<Animator>().SetTrigger("Jump");

            }

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
