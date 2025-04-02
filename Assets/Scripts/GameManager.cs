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
    public float maxScore = 100;
    private float playerKillLimit = -13.5f;

    public int currentCollected = 0;



    private void Start()
    {
        isPlaying = true;
        currentScore = maxScore;
    }//end Start()


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("j"))
        {
            ResetGame();
        }

        //pausing features
        if (Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 0;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            Time.timeScale = 1;
        }


        //score stuff
        if(isPlaying == true)
        {
            currentScore -= 0.03f;
        }

        if(currentScore > maxScore)
        {
            currentScore = maxScore;
        }

        if(currentScore <= 0)
        {
            GameOver();
        }

        //player.transform.position = new Vector2 (playerKillLimit + (currentScore * 0.07f), player.transform.position.y);

    }//end Update()



    public void ResetGame()
    {

        isPlaying = true;
        currentScore = maxScore;
        player.SetActive(true);
        currentCollected = 0;

    }//end ResetGame()


    public void GameOver()
    {
        isPlaying = false;
        player.SetActive(false);
    }//end GameOver()



    public string ScoreDisplay()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }//end ScoreDisplay()



}//end GameManager
