using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverCanvas;
    public GameObject GameScoreCanvas;
    public GameObject GameStartCanvas;
    public Movement bools;

    public void GameOver()
	{
        GameOverCanvas.SetActive(true);
        GameScoreCanvas.SetActive(false);
        bools.isPlay = false;
        Time.timeScale = 0;
	}
    void Start()
    {
        Time.timeScale = 0;
        GameScoreCanvas.SetActive(false);

    }

    public void StartGame()
	{
        GameScoreCanvas.SetActive(true);
        GameStartCanvas.SetActive(false);
        bools.isPlay = true;
        Time.timeScale = 1;
	}

    public void QuitGame()
	{
        Application.Quit();
       
    }

    public void Replay()
	{
        SceneManager.LoadScene(0);
	}

}
