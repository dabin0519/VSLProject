using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CircleSkillVisual : Damage
{
    [SerializeField] private float _radius;
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;
    private Transform _playerTrm;
    private float _theta;
    private bool _active;

    private Color _currentColor;

    private void Awake()
    {
        _spriteRenderer = transform.Find("Visual").GetComponent<SpriteRenderer>();
        _currentColor = _spriteRenderer.color;

        damageAmount = transform.parent.GetComponent<Skill>().DamageAmount;
    }

    private void Update()
    {
        if(_active)
            Rotate();
    }

    public void OnSkill(Transform playerTrm, float theta)
    {
        _active = true;
        _playerTrm = playerTrm;
        _theta = theta * Mathf.Deg2Rad;

        _spriteRenderer.color = _currentColor;
    }

    private void Rotate()
    {
        _theta += _speed * Mathf.Deg2Rad * Time.deltaTime;
        transform.position = new Vector3(_playerTrm.position.x + _radius * Mathf.Cos(_theta),
            _playerTrm.position.y + _radius * Mathf.Sin(_theta));
    }

    public override void OffSkill()
    {
        _spriteRenderer.DOFade(0, 0.2f).OnComplete(() => gameObject.SetActive(false));
    }
}
