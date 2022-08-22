using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] public GameObject[] _levels;
    [SerializeField] private int _currentLevel;
    [SerializeField] private int _overLevel;

    public bool restart;
    public static bool overLevel;
    public static int level = 1;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Level") > 1)
        {
            level = PlayerPrefs.GetInt("Level");
        }
        if (_currentLevel > 0 && !overLevel)
        {
            level = _currentLevel;
            PlayerPrefs.SetInt("Level", level);
            PlayerPrefs.Save();
        }
        LevelController();
    }

    public void LevelController()
    {
        for (int i = 0; i < _levels.Length; i++)
        {
            _levels[i].SetActive(false);
        }

        if (level <= _levels.Length)
        {
            _levels[level - 1].SetActive(true);
        }
        else
        {
            _overLevel = level;
            if (PlayerPrefs.GetString(_overLevel.ToString()) != "")
            {
                int newLevel = Convert.ToInt32(PlayerPrefs.GetString(_overLevel.ToString()));
                _levels[newLevel].SetActive(true);
            }
            else
            {
                int random = Random.Range(0, _levels.Length);
                PlayerPrefs.SetString(_overLevel.ToString(), random.ToString());
                _levels[random].SetActive(true);
            }

        }
    }
}
