using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSkillVisual : MonoBehaviour, IPoolable
{
    [SerializeField] private GameObject _bombEffect;
    [SerializeField] private LayerMask _whatIsEnemy;
    [SerializeField] private float _explosionTime; // 폭발까지 걸리는 시간

    [field: SerializeField] public PoolTypeSO PoolType { get; private set; }

    public GameObject GameObject => gameObject;

    private SpriteRenderer _spriteRenderer;
    private Color _redColor;
    private Color _defaultColor;
    private Pool _myPool;

    private void Awake()
    {
        _spriteRenderer = transform.Find("Visual").GetComponent<SpriteRenderer>();
        _redColor = Color.red;
        _defaultColor = _spriteRenderer.color;
    }

    public void OnSkill(float explosionRange, float damageAmount)
    {
        StartCoroutine(BombCoroutine(explosionRange, _explosionTime, damageAmount));
    }

    private IEnumerator BombCoroutine(float explosionRange, float explosionTime, float damageAmount)
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
        yield return new WaitForSeconds(0.2f);
        _spriteRenderer.enabled = false;

        GameObject newObject = Instantiate(_bombEffect, transform.position, Quaternion.identity);

        // bomb 
        RaycastHit2D[] hitInfos = Physics2D.CircleCastAll(transform.position, explosionRange, Vector2.zero, _whatIsEnemy);
        foreach (var hitInfo in hitInfos)
        {
            if (hitInfo.collider != null && (hitInfo.collider.gameObject.CompareTag("Player") == false) && hitInfo.collider.TryGetComponent(out IDamageAble damageAble))
            {
                damageAble.GetDamage(damageAmount);
            }
        }
        yield return new WaitForSeconds(0.8f);
        PoolManager.Instance.Push(this);
        Destroy(newObject);
    }

    public void SetUpPool(Pool pool)
    {
        _myPool = pool;
    }

    public void ResetItem()
    {
        
    }
}
