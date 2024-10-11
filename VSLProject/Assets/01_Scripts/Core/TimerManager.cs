using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoSingleton<TimerManager>
{
    [SerializeField] private TimerUI _timerUI;

    private int _minute;
    private float _second;

    private void Update()
    {
        CalculateTimer();
    }

    private void CalculateTimer()
    {
        _second += Time.deltaTime;
        if (_second >= 60f)
        {
            _minute++;
            _second = 0;
        }

        _timerUI.UpdateTimerUI(_minute, (int)_second);
    }
}
