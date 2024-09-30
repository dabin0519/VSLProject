using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSkillVisual : Damage
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _offsetAngle;

    private Vector3 _dir;
    private bool _onSkill;
    private Transform _visualTrm;
    private Transform _playerTrm;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _visualTrm = transform.Find("Visual");
        _spriteRenderer = _visualTrm.GetComponent<SpriteRenderer>();
        _playerTrm = GameManager.Instance.PlayerTrm;
    }

    public void Init(Vector3 mouseDir)
    {
        _dir = mouseDir.normalized;
        _onSkill = true;
        float angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
        angle += _offsetAngle;

        transform.position = _playerTrm.position;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        _spriteRenderer.enabled = true;
    }

    public override void OffSkill()
    {
        _onSkill = false;
        _spriteRenderer.enabled = false;
    }

    private void FixedUpdate()
    {
        if(_onSkill)
        {
            transform.position += _dir.normalized * _moveSpeed * Time.fixedDeltaTime;
        }
    }
}
