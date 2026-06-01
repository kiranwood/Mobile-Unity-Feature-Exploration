using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public GameObject Player; 
    [SerializeField] public TextMeshProUGUI Text;
    [SerializeField] private string _winScreenName = "WinScreen";

    private float _currentTime;
    private Vector3 _startPos;

    private void OnEnable()
    {
        _currentTime = 0;
        Instance = this;
        _startPos = Player.transform.position;
    }

    public void FixedUpdate()
    {
        _currentTime += Time.deltaTime;
        UpdateTimerText();
    }

    // Updates UI
    private void UpdateTimerText()
    {
        // Gets time
        string minutes = Mathf.FloorToInt(_currentTime / 60).ToString("00");
        string seconds = Mathf.RoundToInt(_currentTime % 60).ToString("00");

        Text.text = minutes + ":" + seconds;
    }
    
    // Moves player back to start
    public void LoseGame()
    {
        Player.transform.position = _startPos;
        Player.transform.rotation = Quaternion.identity;
    }

    public void WinGame()
    {
        PlayerPrefs.SetFloat("CurrentScore", _currentTime);

        // No Highscore Set
        if (PlayerPrefs.HasKey("HighScore") == false)
        {
            PlayerPrefs.SetFloat("HighScore", _currentTime);
        }
        else if (PlayerPrefs.GetFloat("HighScore") > _currentTime)
        {
            PlayerPrefs.SetFloat("HighScore", _currentTime);
        }

        SceneManager.LoadScene(_winScreenName);
    }
}
