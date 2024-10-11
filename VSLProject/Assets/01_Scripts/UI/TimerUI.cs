using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    private TextMeshProUGUI _timerText;

    private void Awake()
    {
        _timerText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateTimerUI(int minute, int second)
    {
        _timerText.text = minute.ToString("D2") + " : " + second.ToString("D2");
    }
}
