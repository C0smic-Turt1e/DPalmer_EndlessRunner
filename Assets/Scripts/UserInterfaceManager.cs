using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;
using UnityEngine.UI;

public class UserInterfaceManager : MonoBehaviour
{
    #region Singleton definition

    public static UserInterfaceManager Instance;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }

    }//end Awake()

    #endregion

    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField] private Slider healthBar;

    [SerializeField] private Button startButton;
    [SerializeField] private GameObject startScreen;

    [SerializeField] private GameObject loseScreen;
    [SerializeField] private Button loseButton;

    private void OnGUI()
    {
        scoreDisplay.text = GameManager.Instance.DistanceDisplay();
        healthBar.value = GameManager.Instance.currentScore;

    }//end OnGUI()



    private void Start()
    {

        loseScreen.SetActive(false);
        loseButton.gameObject.SetActive(false);

    }//end Start()



    public void StartGame()
    {
        startScreen.SetActive(false);
        Time.timeScale = 1;
        GameManager.Instance.isPlaying = true;
    }//end StartGame()



    public void LoseGame()
    {

        loseScreen.SetActive(true);
        loseButton.gameObject.SetActive(true);
        loseButton.interactable = true;

    }//end LoseGame()


    public void RestartGame()
    {
        loseScreen.SetActive(false);
        loseButton.gameObject.SetActive(false);
    }



}//end UserInterfaceManager()
