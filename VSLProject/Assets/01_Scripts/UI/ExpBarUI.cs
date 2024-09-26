using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExpBarUI : MonoBehaviour
{
    private Transform _currentExpTrm;
    private TextMeshProUGUI _levelText;
    private bool _maxLevel;

    private void Awake()
    {
        _currentExpTrm = transform.Find("CurrentExp");
        _levelText = transform.Find("LevelText").GetComponent<TextMeshProUGUI>();
        _maxLevel = false;
    }

    public void UpdateUI(float exp, float maxExp, int level)
    {
        if (_maxLevel) return;
        _currentExpTrm.localScale = new Vector3(exp / maxExp, _currentExpTrm.localScale.y);
        _levelText.text = "Lv " + level.ToString("D2");
    }

    public void MaxLevelUI()
    {
        _levelText.text = "Lv MAX";
        _currentExpTrm.localScale = new Vector3(1, _currentExpTrm.localScale.y);
        _maxLevel = true;
    }
}
