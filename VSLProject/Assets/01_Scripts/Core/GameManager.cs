using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public event Action GameStartEvent;
    public Transform PlayerTrm { get; private set; }
    public Player Player { get; private set; }

    [Header("--Game Info--")]
    public int killCnt;

    private void Awake()
    {
        PlayerTrm = GameObject.Find("Player").transform;
        Player = PlayerTrm.GetComponent<Player>();
    }

    private void Start()
    {
        GamePause(true);
        DelayTime(1f, () => { GameStartEvent?.Invoke(); }); // �� ���߿� �÷��� ���� �� ýũ�ؼ� �� �����Ǹ� �̺�Ʈ �������ٵ�?
    }

    public void GamePause(bool isPause)
    {
        float timeSacle = isPause ? 0f : 1f;

        Time.timeScale = timeSacle;
    }

    public void DelayTime(float time, Action callback)
    {
        StartCoroutine(DelayCoroutine(time, callback));
    }

    private IEnumerator DelayCoroutine(float time, Action callback)
    {
        yield return new WaitForSecondsRealtime(time);
        callback?.Invoke();
    }
}
