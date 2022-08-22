using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : Singleton<Level>
{
    [SerializeField] private GameObject _LevelFailedScreen;
    [SerializeField] private GameObject _LevelCompletedScreen;

    public void LevelFailed()
    {
        _LevelFailedScreen.SetActive(true);
    }
    public void LevelCompleted()
    {
        _LevelCompletedScreen.SetActive(true);
    }
    public void RestartTheGame()
    {
        LevelManager.Instance.restart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void NextLevel()
    {
        LevelManager.level++;
        PlayerPrefs.SetInt("Level", LevelManager.level);
        PlayerPrefs.Save();
        _LevelCompletedScreen.SetActive(false);
        if (LevelManager.level > LevelManager.Instance._levels.Length)
        {
            LevelManager.overLevel = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        GameController.Instance.playerMoving = true;
        LevelManager.Instance.LevelController();
    }
}
