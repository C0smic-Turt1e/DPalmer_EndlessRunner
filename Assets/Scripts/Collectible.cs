using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    public void Collected()
    {

        GameManager.Instance.currentCollected++;
        Destroy(gameObject);

    }//end Collected()



}//end Collectible
