using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : Singleton<GameController>
{
    private Player _player;

    [Header("TouchController")]
    [SerializeField] public GameObject touchToStartCanvas;
    [SerializeField] public bool playerMoving = false;

    [Header("LevelProgress")]
    [SerializeField] private TextMeshProUGUI _currentLevelText, _nextLevelText;
    [SerializeField] private Image[] _levelSteps;
    [SerializeField] private Color _color;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private ParticleSystem[] _particleStep;

    private int _platformCount;
    private int _currentPlatformPassed = 0;


    [SerializeField, ReadOnly] public bool initialTouch = true;


    private void Start()
    {
        _platformCount = GameObject.FindGameObjectsWithTag("Platform").Length;
        _player = GameObject.FindObjectOfType<Player>();
    }
    private void Update()
    {
        UpdateLevelText();
        if (!LevelManager.Instance.restart)
        {
            if (Input.GetMouseButtonDown(0) && initialTouch)
            {
                initialTouch = false;
                playerMoving = true;
                touchToStartCanvas.SetActive(false);
            }
        }
    }

    public void NextLevelSteps()
    {
        if (_currentPlatformPassed < _platformCount)
        {
            _levelSteps[_currentPlatformPassed].color = _color;
            _particleStep[_currentPlatformPassed].Play();
            _currentPlatformPassed++;
        }
        else
        {
            for (int i = 0; i < _platformCount; i++)
            {
                _levelSteps[i].color = _color;
                _particleStep[i].Play();
            }
        }
        if (_currentPlatformPassed == _platformCount)
        {
            StartCoroutine(LevelCheck());   
        }
    }
    IEnumerator LevelCheck()
    {
        yield return new WaitForSeconds(3f);
        _currentPlatformPassed = 0;
        foreach (var step in _levelSteps)
        {
            step.color = _defaultColor;
        }
        playerMoving = false;
        Level.Instance.LevelCompleted();
    }
    public void UpdateLevelText()
    {
        _currentLevelText.text = LevelManager.level.ToString();
        int nextLevel = LevelManager.level + 1;
        _nextLevelText.text = nextLevel.ToString();
    }
}
