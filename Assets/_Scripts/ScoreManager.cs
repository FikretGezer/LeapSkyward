using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    private int score = 0;

    public static ScoreManager Instance;
    private void Awake() {
        if(Instance == null) Instance = this;
        UpdateScore();
    }
    public void UpdateScore()
    {
        score++;
        _score.text = score.ToString();
    }
}
