using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelMenu : MonoBehaviour
{
    public Button[] buttons;

    private void Awake()
    {
        int zamcenyLevel = PlayerPrefs.GetInt("ZamcenyLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for(int i = 0; i < zamcenyLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }

   public void OpenLevel(int levelId)
    {
        string levelName = "level " + levelId;
        SceneManager.LoadScene(levelName);
    }
}
