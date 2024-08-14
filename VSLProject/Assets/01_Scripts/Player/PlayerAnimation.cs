using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PlayerAnimation : Player
{
    private Animator _playerAnimator;
    private SpriteRenderer _playerSpriteRenderer;
    private Transform _playerVisualTrm;
    private GhostEffect _ghostEffect;

    protected override void Awake()
    {
        base.Awake();

        _playerVisualTrm = transform.Find("Visual");
        _playerAnimator = _playerVisualTrm.GetComponent<Animator>();
        _playerSpriteRenderer = _playerVisualTrm.GetComponent<SpriteRenderer>();
        _ghostEffect = GetComponent<GhostEffect>();
    }

    private void LateUpdate()
    {
        _playerAnimator.SetFloat("Speed", Mathf.Abs(_playerController.InputVector.x));
        Flip();
        Ghost();
    }

    private void Ghost()
    {
        Vector2 inputVector = _playerController.InputVector;
        _ghostEffect.spawnGhost = Mathf.Abs(inputVector.x) > 0 || Mathf.Abs(inputVector.y) > 0; 
    }

    private void Flip()
    {
        if (_playerController.InputVector.x == 0)
            return;
        _playerSpriteRenderer.flipX = _playerController.InputVector.x < 0;
    }

    public void OnDamageAnimation()
    {
        //_playerSpriteRenderer.DOColor()
        // 직접 애니메이션 코딩을 할지 그냥 단순 코딩을 할지가 고민이요. 
        _playerAnimator.SetTrigger("Damage");
    }
}
