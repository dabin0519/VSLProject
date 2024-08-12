using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerController _playerController;
    private Animator _playerAnimator;
    private SpriteRenderer _spriteRenderer;
    private Transform _playerVisualTrm;
    private GhostEffect _ghostEffect;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _playerVisualTrm = transform.Find("Visual");
        _playerAnimator = _playerVisualTrm.GetComponent<Animator>();
        _spriteRenderer = _playerVisualTrm.GetComponent<SpriteRenderer>();
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
        _spriteRenderer.flipX = _playerController.InputVector.x < 0;
    }
}
