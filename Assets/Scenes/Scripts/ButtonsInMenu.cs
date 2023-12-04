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
    }

    public void ButtonClickMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ButtonClickVyber()
    {
        SceneManager.LoadScene(8);
    }

    public void ButtonClickResetHS()
    {
        HScore = 0;
        text.text = "Highest Score: " + HScore.ToString();
    }
}
