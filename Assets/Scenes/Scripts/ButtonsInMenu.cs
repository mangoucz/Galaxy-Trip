using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsInMenu : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int HScore;

    public void ButtonClickNewGame()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("PreviousSceneIndex", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
    }

    public void ButtonClickMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ButtonClickVyber()
    {
        SceneManager.LoadScene(8);
        PlayerPrefs.SetInt("PreviousSceneIndex", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
    }

    public void ButtonClickResetHS()
    {
        HScore = 0;
        text.text = "Highest Score: " + HScore.ToString();
        PlayerPrefs.SetInt("HScore", 0);
        PlayerPrefs.Save();
    }
}
