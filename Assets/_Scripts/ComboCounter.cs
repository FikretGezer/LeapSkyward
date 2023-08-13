using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComboCounter : MonoBehaviour
{
    [Header("Combo Props")]
    [SerializeField] private float timerMaxTime = 3f;
    [SerializeField] private TMP_Text _sayacTxt;
    [SerializeField] private TMP_Text _comboCountTxt;

    private float maxTime;
    [HideInInspector] public Animator _comboAnimator;

    [Header("Combo Bar")]
    [SerializeField] private Image _comboBarBG;
    private float _comboBarMax;

    private int comboCount = 0;
    public static ComboCounter Instance;
    private void Awake() {
        if(Instance == null) Instance = this;

        maxTime = timerMaxTime;
        _comboBarMax = maxTime;
        _comboBarBG.fillAmount = maxTime / _comboBarMax;

        _comboAnimator = _comboCountTxt.GetComponent<Animator>();
    }
    private void Update() {
        FillUpBar();
        if(comboCount > 0) _comboCountTxt.gameObject.SetActive(true);
        else
        {
            //_comboCountTxt.text = (comboCount * 10).ToString();
            _comboCountTxt.gameObject.SetActive(false);
        }           
    }
    private IEnumerator ComboTimer()
    {
        maxTime = timerMaxTime;
        comboCount++;
        _comboCountTxt.text = $"COMBO\n{comboCount}x";
        _comboAnimator.SetTrigger("Combod");
        while(maxTime > 0)
        {
            maxTime -= Time.deltaTime;
            if(maxTime > 0f)
                _sayacTxt.text = $"{maxTime:0.00}";//maxTime.ToString();
            yield return null;
        }
        ScoreManager.Instance.UpdateScore(comboCount * 10);
        _comboCountTxt.text = (comboCount * 10).ToString();
        comboCount = 0;
        //_comboCountTxt.text = comboCount.ToString(); 
        Debug.Log("<color=red> Reset Combo </color>");
    }
    private void FillUpBar()
    {
        if(_comboBarBG.fillAmount > -0.01f)
            _comboBarBG.fillAmount = maxTime / _comboBarMax;
        else
            _comboBarBG.fillAmount = 0f;        
    }
    public void StartRoutine()
    {
        StopCoroutine(nameof(ComboTimer));
        StartCoroutine(nameof(ComboTimer));
    }
    
}
