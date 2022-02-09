using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public float BrickSpeed;
    public float BrickMinHealth;
    public float BrickMaxHealth;
    public bool ActiveSpawner;
    public float SpawnCD;
    public float YspawnOffset;

    public float BallSpeed;
    public bool Firing;

    public float BulletSpeed;
    public float BulletDamage;
    public float BulletCount;
    public float BulletFireRate;
    public float MGcd;

    public float RocketSpeed;
    public float RocketDamage;
    public float RocketCount;
    public float RocketFireRate;
    public float RocketBlastRadius;
    public float RocketCD;

    public float VoidSpeed;
    public float VoidRadius;
    public float VoidCD;
    public float VoidActiveTime;

    public int ScoreToWin;
    public int ScoreMultiplier;
    public int CurrentScore;

    private AudioSource[] allAudioSources;
    public RocketLuncher RL;
   

    public UiManager UI;
    public State CurrentState { get; private set; }

    public enum State
    {
        Playing,
        Won,
        Loss,
    }
    private void Awake()
    {
        Time.timeScale = 1f;
        ScoreToWin = ScoreMultiplier * (LevelIndex + 1);
        Firing = true;
        UI.SetProgress(CurrentScore);
        UI.SetWinScr(ScoreToWin);

    }
   
    public void MuteAll()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audio in allAudioSources)
        {
            audio.volume = 0f;
        }
    }

    public void UnMuteAll()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audio in allAudioSources)
        {
            audio.volume = 0.2f;
        }
    }

    public void RocketBlastSound()
    {
        RL.BlastSound();
    }

    private const string LevelIndexKey = "LevelIndex";
    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }


    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        MuteAll();
        PlayerPrefs.DeleteAll();
        CurrentScore = 0;
        UI.Lose();
        PauseGame();
    }

    public void OnPlayerWin()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Won;
        LevelIndex++;
        MuteAll();
        UI.Win();
        PauseGame();
    }

    public void IncrementScore()
    {
        CurrentScore++;
        UI.SetProgress(CurrentScore);
        UI.SetCurScr(CurrentScore);
        if (CurrentScore >= ScoreToWin)
        {
            OnPlayerWin();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
