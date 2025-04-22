using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAnims : MonoBehaviour
{
    
    private void PauseAnimation()
    {

        GetComponent<Animator>().speed = 0;

    }//end PauseAnimation()

}//end PauseAnims
