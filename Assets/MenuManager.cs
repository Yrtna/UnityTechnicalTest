using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject killScreen;

    [SerializeField]
    private GameObject inGameUI;

    [SerializeField]
    private Text killScore;

    [SerializeField]
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GetComponent<ScoreManager>();
    }

    private void Update()
    {
        killScore.text = scoreManager.ScoreString();
        if (Input.GetButtonDown("Cancel"))
        {
            ExitApplication();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        killScreen.SetActive(true);
        inGameUI.SetActive(false);
    }

    public void ReloadLevel()
    {
        Time.timeScale = 1f;
        killScreen.SetActive(false);
        inGameUI.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}