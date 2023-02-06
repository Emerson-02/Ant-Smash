using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public AudioClip[] audioEnemies;
    [HideInInspector] public int totalScore;
    [HideInInspector] public int enemyCount;
    private UIController uiController;
    public Transform allEnemiesParent;
    private Spawner spawner;
    [HideInInspector] public int highscore;

    private void Awake() 
    {
        uiController = FindObjectOfType<UIController>();
        spawner = FindObjectOfType<Spawner>();
        highscore = GetScore();
    }

    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        enemyCount = 0;
        spawner.gameObject.GetComponent<Spawner>().enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        totalScore = 0;
        enemyCount = 0;
        uiController.txtScore.text = totalScore.ToString();
        spawner.gameObject.GetComponent<Spawner>().enabled = true;
    }

    public void Restart()
    {
        totalScore = 0;
        enemyCount = 0;
        uiController.txtScore.text = totalScore.ToString();

        foreach (Transform child in allEnemiesParent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void SaveScore()
    {
        if(totalScore > highscore)
        {
            PlayerPrefs.SetInt("highscore", totalScore);
            uiController.txtHighScore.text = "Highcore: " + totalScore.ToString();
        }
    }

    public int GetScore()
    {
        highscore = PlayerPrefs.GetInt("highscore");
        return highscore;
    }
}
