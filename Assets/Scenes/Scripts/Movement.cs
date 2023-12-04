using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Movement : MonoBehaviour
{
    #region Promenne
    public GameObject box;
    public GameObject box2;

    [SerializeField]
    float MovementSpeed;

    private float timer;
    private bool couvat;


    public TMP_Text score;
    public static int charge;

    private Quaternion plusRotace = Quaternion.Euler(0, -90, 0);
    private Quaternion plusRotace2 = Quaternion.Euler(0, -180, 0);
    #endregion

    public string nextLevelName = "Level 3"; 


    void Start()
    {
        couvat = false;

        if(PlayerPrefs.GetInt("PreviousSceneIndex") == 0)
        {
            charge = 0;
        }
        else if (PlayerPrefs.GetInt("PreviousSceneIndex") == 7)
        {
            charge = 0;
        }
        else if (PlayerPrefs.HasKey("Score"))
        {
            charge = PlayerPrefs.GetInt("Score");
        }
        
        Debug.Log(PlayerPrefs.GetInt("PreviousSceneIndex"));
    }
    void Update()
    {
        ZmenaTextu();
        #region Couvani
        if (couvat == true)
        {
            timer = timer + Time.deltaTime;
        }
        transform.position += transform.forward * MovementSpeed * Time.deltaTime;
        if (timer > 0.2)
        {
            transform.rotation = transform.rotation * plusRotace;
            couvat = false;
            timer = 0;
        }
        #endregion
        #region SpawnBoxu
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit))
            {
                if(hit.point.y <= 0.3)
                {
                    Instantiate(box, hit.point, Quaternion.identity);
                }
                else
                {
                    Debug.Log("Zde jiz box je");
                }
                
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (charge >= 1) 
            {
                charge--;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.point.y <= 0.3)
                    {
                        Instantiate(box2, hit.point, Quaternion.identity);
                    }
                    else
                    {
                    Debug.Log("Zde jiz box je");
                    }
                }
            }
        }
        #endregion
    }

    public static void ChangeCharge(int newCharge)
    {
        charge = newCharge;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            couvat = true;
            transform.rotation = transform.rotation * plusRotace2;
        }
        if (collision.gameObject.CompareTag("Box2"))
        {
            transform.rotation = transform.rotation * plusRotace2;
        }
        if (collision.gameObject.CompareTag("SpecialBox"))
        {
            Scene scena = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scena.name);
        }
        if (collision.gameObject.CompareTag("PickUp"))
        {
            charge++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("???"))
        {
          
            ZrychliHrace();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("End"))
        {
            OtevritLevel();
            LoadNextLevel();
            PlayerPrefs.SetInt("Score", charge);
            PlayerPrefs.SetInt("PreviousSceneIndex", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.Save();
        }
        if (collision.gameObject.CompareTag("Border"))
        {
            couvat = true;
            transform.rotation = transform.rotation * plusRotace2;
        }
    }
    private void LoadNextLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentLevelIndex + 1;

        if (nextLevelIndex <= 6)
        {
            SceneManager.LoadScene(nextLevelName);
        }
        else
        {
            SceneManager.LoadScene(7); //VicotryScreen
            Debug.Log("Všechny levely jsou dokonèeny!");
            
        }
    }
    private void ZrychliHrace()
    {
        
        float novaRychlost = MovementSpeed * 2; 
        MovementSpeed = novaRychlost;
    }
    void OtevritLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex")) 
        { 
        PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("ZamcenyLevel", PlayerPrefs.GetInt("ZamcenyLevel", 1) + 1);
        PlayerPrefs.Save();
        }
    }
    public void ZmenaTextu()
    {
        score.text = charge.ToString();
    }
}