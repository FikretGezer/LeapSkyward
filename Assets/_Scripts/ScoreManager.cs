using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;

    public static ScoreManager Instance;
    private int score = 0;
    private void Awake() {
        if(Instance == null) Instance = this;
        if(!PlayerPrefs.HasKey("HighestScore")) PlayerPrefs.SetInt("HighestScore", 0);
        UpdateScore(0);
    }
    public void UpdateScore(int addingScore)
    {
        score += addingScore;
        _score.text = score.ToString();
    }
    public void EndScoreToText(TMP_Text currentScoreText, TMP_Text highestScoreText)
    {
        var comboCount = ComboCounter.Instance.comboCount;
        if(CameraMovement.Instance.isHeDead && comboCount > 0)
        {
            score += comboCount * 10;
            ComboCounter.Instance.comboCount = 0;
        } 
        currentScoreText.text = score.ToString();
        var highestScore = PlayerPrefs.GetInt("HighestScore");
        if(score > highestScore)
        {
            PlayerPrefs.SetInt("HighestScore", score);
        }
        highestScoreText.text = highestScore.ToString();
    }
}
