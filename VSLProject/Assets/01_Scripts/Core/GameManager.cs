using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public event Action GameStartEvent;
    public Transform PlayerTrm { get; private set; }

    private void Awake()
    {
        PlayerTrm = GameObject.Find("Player").transform;
    }

    private void Start()
    {
        GamePause(true);
        DelayTime(1f, () => { GameStartEvent?.Invoke(); }); // 음 나중엔 플래그 같은 거 첵크해서 다 정리되면 이벤트 발행해줄듯?
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
