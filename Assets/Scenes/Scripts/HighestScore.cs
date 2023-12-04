using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HighestScore : MonoBehaviour
{
    private int HScore;
    private int newScore;
    public TextMeshProUGUI text;

    void Start()
    {
        newScore = Movement.charge;

        if (PlayerPrefs.HasKey("HScore"))
        {
            HScore = PlayerPrefs.GetInt("HScore");
        }
        else
        {
            HScore = 0;
        }

        if (newScore > HScore)
        {
            HScore = newScore;
            text.text = "Highest Score: " + HScore.ToString();
            PlayerPrefs.SetInt("HScore", HScore);
            PlayerPrefs.Save();
        }
        else
        {
            text.text = "Highest Score: " + HScore.ToString();
        }
    }
}
