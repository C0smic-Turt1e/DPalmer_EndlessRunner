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



    private void OnGUI()
    {
        scoreDisplay.text = GameManager.Instance.ScoreDisplay();
        healthBar.value = GameManager.Instance.currentScore;

    }//end OnGUI()




}//end UserInterfaceManager()
