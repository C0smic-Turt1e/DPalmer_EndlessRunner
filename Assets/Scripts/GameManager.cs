using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton definition

    public static GameManager Instance;



    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }

    }//end Awake()

    #endregion

    public GameObject player;

    public bool isPlaying;
    public float currentScore;

    public int currentCollected = 0;



    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("j"))
        {
            ResetGame();
        }

    }//end Update()



    public void ResetGame()
    {

        isPlaying = true;
        currentScore = 0;
        player.SetActive(true);

    }//end ResetGame()



}//end GameManager
