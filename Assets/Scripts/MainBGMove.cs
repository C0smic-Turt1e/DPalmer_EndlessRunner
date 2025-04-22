using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainBGMove : MonoBehaviour
{

    [SerializeField] private GameObject backgroundObject;
    private float spriteLength;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {

        spriteLength = backgroundObject.GetComponentInChildren<SpriteRenderer>().bounds.size.x;

    }//end Start()



    // Update is called once per frame
    void Update()
    {
        distance += (Time.deltaTime * 2);

        transform.position = new Vector3(-distance, transform.position.y, transform.position.z);

        if (-transform.position.x >= spriteLength)
        {

            distance = 0;


        }

    }//end Update()



}//end MainBGMove
