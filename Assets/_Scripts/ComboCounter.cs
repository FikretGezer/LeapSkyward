using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboCounter : MonoBehaviour
{
    [SerializeField] private float timerMaxTime = 3f;
    [SerializeField] private TMP_Text _sayacTxt;
    [SerializeField] private TMP_Text _comboCountTxt;

    private int comboCount = 0;
    public static ComboCounter Instance;
    private void Awake() {
        if(Instance == null) Instance = this;
    }
    private IEnumerator Timer()
    {
        var maxTime = timerMaxTime;
        comboCount++;
        _comboCountTxt.text = comboCount.ToString(); 
        while(maxTime > 0)
        {
            maxTime -= Time.deltaTime;
            _sayacTxt.text = maxTime.ToString();
            yield return null;
        }
        ScoreManager.Instance.UpdateScore(comboCount * 10);
        comboCount = 0;
        _comboCountTxt.text = comboCount.ToString(); 
        Debug.Log("<color=red> Reset Combo </color>");
    }
    public void StartRoutine()
    {
        StopCoroutine(nameof(Timer));
        StartCoroutine(nameof(Timer));
    }
    
}
