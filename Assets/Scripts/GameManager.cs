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
    public float newPoints = 0;
    private float addPointsTimer = 0;
    public float maxScore = 100;
    private float playerKillLimit = -13.5f;

    public int currentCollected = 0;

    public float distance = 0;
    public float gameSpeed = 1;
    private float difficultyIncreaser = 0;


    private void Start()
    {
        isPlaying = false;
        Time.timeScale = 0;
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
            currentScore -= Time.deltaTime * 4;
        }

        if(currentScore > maxScore)
        {

            currentScore = maxScore;
            newPoints = 0;
            addPointsTimer = 0;

        }else
        {

            //adding points incrementally
            if (newPoints > addPointsTimer)
            {
                currentScore += Time.deltaTime * 50;
                addPointsTimer += Time.deltaTime * 50;
            }
            else
            {
                newPoints = 0;
                addPointsTimer = 0;
            }

        }

        if (currentScore <= 0)
        {
            GameOver();
        }

        player.transform.position = new Vector3(playerKillLimit + (currentScore * 0.07f), player.transform.position.y, player.transform.position.z);

        distance += (Time.deltaTime * gameSpeed * 2);
        DifficultyIncrease();

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
        Time.timeScale = 0;

    }//end GameOver()



    public string ScoreDisplay()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }//end ScoreDisplay()


    public string DistanceDisplay()
    {
        return Mathf.RoundToInt(distance).ToString();
    }//end ScoreDisplay()



    public void DifficultyIncrease()
    {

        if (distance < 50)
        {

            gameSpeed = 1;
            difficultyIncreaser = 50;

        } else if (distance >= 50)
        {
            if (distance >= difficultyIncreaser)
            {

                gameSpeed += 0.5f;
                difficultyIncreaser = difficultyIncreaser * 1.5f;

            }
        }

    }//end DifficultyIncrease()



}//end GameManager
