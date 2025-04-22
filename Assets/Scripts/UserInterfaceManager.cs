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

    private void OnGUI()
    {
        scoreDisplay.text = GameManager.Instance.DistanceDisplay();
        healthBar.value = GameManager.Instance.currentScore;

    }//end OnGUI()


    public void StartGame()
    {
        startScreen.SetActive(false);
        Time.timeScale = 1;
    }




}//end UserInterfaceManager()
