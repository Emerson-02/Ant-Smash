using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    public TMP_Text txtScore;
    public Image[] imageLifes;
    public GameObject panelGame, panelPause, panelMainMenu, allLifes;
    private GameController gameController;


    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        panelMainMenu.gameObject.SetActive(true);
        panelGame.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score)
    {
        txtScore.text = score.ToString();
    }

    public void ButtonStartGame()
    {
        panelMainMenu.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
        gameController.StartGame();
    }

    public void ButtonExitGame()
    {
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
    }

    public void ButtonPause()
    {
        Time.timeScale = 0f;
        panelGame.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(true);
    }

    public void ButtonResume()
    {
        Time.timeScale = 1f;
        panelPause.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
    }

    public void ButtonRestart()
    {
        Time.timeScale = 1f;
        panelPause.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
        gameController.Restart();

        foreach (Transform child in allLifes.transform)
        {
            child.gameObject.SetActive(true); // ativa todas as vidas novamente
        }
    }

    public void ButtonBackMainMenu()
    {
        Time.timeScale = 1f;
        panelPause.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(false);
    }
}
