using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private string _levelSceneName = "LevelScene";
    [SerializeField] private string _mainMenuSeneName = "MainMenu";

    private void OnEnable()
    {
        SetCurrentScoreText();
        SetHighScoreText();
    }

    // Loads level scene
    public void RestartLevel()
    {
        SceneManager.LoadScene(_levelSceneName);
    }

    // Loads main menuu scene
    public void MainMenu()
    {
        SceneManager.LoadScene(_mainMenuSeneName);
    }

    // Sets HighScore Text
    private void SetCurrentScoreText()
    {
        _currentScoreText.text = "Time: " + GetTime(PlayerPrefs.GetFloat("CurrentScore"));
    }

    // Sets current score text
    private void SetHighScoreText()
    {
        _highScoreText.text = "Best Time:\n" + GetTime(PlayerPrefs.GetFloat("HighScore"));
    }

    private string GetTime(float time)
    {
        // Gets time
        string minutes = Mathf.FloorToInt(time / 60).ToString("00");
        string seconds = Mathf.RoundToInt(time % 60).ToString("00");

        return minutes + ":" + seconds;
    }
}
