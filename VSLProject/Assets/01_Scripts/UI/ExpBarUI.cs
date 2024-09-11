using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExpBarUI : MonoBehaviour
{
    private Transform _currentExpTrm;
    private TextMeshProUGUI _levelText;

    private void Awake()
    {
        _currentExpTrm = transform.Find("CurrentExp");
        _levelText = transform.Find("LevelText").GetComponent<TextMeshProUGUI>();
    }

    public void UpdateUI(float exp, float maxExp, int level)
    {
        _currentExpTrm.localScale = new Vector3(exp / maxExp, _currentExpTrm.localScale.y);
        _levelText.text = "Lv " + level.ToString("D2");
    }
}
