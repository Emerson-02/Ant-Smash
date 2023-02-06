using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    public TMP_Text txtScore;
    public Image[] imageLifes;
    public GameObject panelGame, panelPause, allLifes;
    private GameController gameController;


    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        panelGame.gameObject.SetActive(true);
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
