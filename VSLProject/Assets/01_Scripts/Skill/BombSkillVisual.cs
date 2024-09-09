using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSkillVisual : MonoBehaviour
{
    [SerializeField] private GameObject _bombEffect;

    private SpriteRenderer _spriteRenderer;
    private Color _redColor;
    private Color _defaultColor;

    private void Awake()
    {
        _spriteRenderer = transform.Find("Visual").GetComponent<SpriteRenderer>();
        _redColor = Color.red;
        _defaultColor = _spriteRenderer.color;
    }

    public void OnSkill(float explosionRange, float explosionTime, float damageAmout)
    {
        StartCoroutine(BombCoroutine(explosionRange, explosionTime, damageAmout));
    }

    private IEnumerator BombCoroutine(float explosionRange, float explosionTime, float damageAmout)
    {
        int cnt = 3;

        for(int i = 0; i < cnt; ++i)
        {
            float time =  explosionTime / (cnt * 2);
            _spriteRenderer.DOColor(_redColor, time).OnComplete(() =>
            {
                _spriteRenderer.DOColor(_defaultColor, time);
            });
            yield return new WaitForSeconds(time * 2);
        }

        Instantiate(_bombEffect, transform.position, Quaternion.identity);

        // bomb 
        RaycastHit2D hitInfo = Physics2D.CircleCast(transform.position, explosionRange, Vector2.zero);
        if(hitInfo.collider != null && hitInfo.collider.TryGetComponent(out IDamageAble damageAble))
        {
            damageAble.GetDamage(damageAmout);
        }
    }
}
