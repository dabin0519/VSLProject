using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAnimation : MonoBehaviour, IAnimation
{
    [SerializeField] private float _idleDuration;
    [SerializeField] private float _idleVelocity;

    private bool _finishIdleCoolTime = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            IdleAnimation();
    }

    public void IdleAnimation()
    {
        if (!_finishIdleCoolTime)
            return;

        _finishIdleCoolTime = false;
        float currentScaleY = transform.localScale.y;

        transform.DOScale(currentScaleY * _idleVelocity,_idleDuration / 2)
            .OnComplete(() =>
            {
                transform.DOScale(currentScaleY, _idleDuration / 2)
                .OnComplete(() => _finishIdleCoolTime = true);
            });
    }
}
