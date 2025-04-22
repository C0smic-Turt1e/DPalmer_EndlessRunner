using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundMove : MonoBehaviour
{

    public float spriteLength;
    private float spriteStartPos;
    [SerializeField] private SpriteRenderer spriteRend;
    public GameObject background;
    public float parallaxSpeed;
    public float distanceMoved;

    // Start is called before the first frame update
    void Start()
    {

        spriteStartPos = transform.position.x;
        spriteLength = spriteRend.bounds.size.x;

    }//end Start()

    // Update is called once per frame
    void Update()
    {
        distanceMoved += Time.deltaTime * parallaxSpeed;

        if (distanceMoved <= -spriteLength)
        {

            transform.position = new Vector3(spriteStartPos, transform.position.y, transform.position.z);
            distanceMoved = 0;

        } else
        {

            transform.position = new Vector3(spriteStartPos + distanceMoved, transform.position.y, transform.position.z);

        }
            

    }//end Update()



}//end BackgroundMove
