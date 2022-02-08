using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameMaster GM;
    public Text CurrentLvl;
    public Text NextLvl;
    public Slider LvlProgress;
    public GameObject WinPanel;
    public GameObject LosePanel;
    public GameObject PausePanel;

    private void Start()
    {
        int curlvl = GM.LevelIndex + 1;
        CurrentLvl.text = curlvl.ToString();
        int nextlvl = GM.LevelIndex + 2;
        NextLvl.text = nextlvl.ToString();
    }

    public void Lose()
    {
        LosePanel.SetActive(true);
    }

    public void Win()
    {
        WinPanel.SetActive(true);
    }
    public void Pause()
    {
        GM.MuteAll();
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
    }
    public void Resume()
    {
        GM.UnMuteAll();
        Time.timeScale = 1f;
        PausePanel.SetActive(false);

    }

    public void SetProgress(float score)
    {
        float currentProgress = Mathf.InverseLerp(0, GM.ScoreToWin, score);
        LvlProgress.value = currentProgress;
    }

}
