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
        UpdateScore(0);
    }
    public void UpdateScore(int addingScore)
    {
        score += addingScore;
        _score.text = score.ToString();
    }
}
