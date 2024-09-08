using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public event Action GameStartEvent;

    private void Start()
    {
        GameStartEvent?.Invoke(); // �� ���߿� �÷��� ���� �� ýũ�ؼ� �� �����Ǹ� �̺�Ʈ �������ٵ�?
    }

    public void GamePause(bool isPause)
    {
        float timeSacle = isPause ? 0f : 1f;

        Time.timeScale = timeSacle;
    }
}
