using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DiceSkillVisual : MonoBehaviour, IPoolable
{
    [SerializeField] private float _rollDuration;
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private float _dropDistance;
    [SerializeField] private float _power;
    [field:SerializeField] public PoolTypeSO PoolType {  get; private set; }
    [SerializeField] private PoolTypeSO _bulletType;

    public GameObject GameObject => gameObject;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private float _spawnTime;
    private float _time;
    private float _currentY;
    private float _damageAmount;
    private bool _firstBounce;
    private bool _finishRoll;
    private Pool _myPool;

    private readonly int _rollTriggerHash = Animator.StringToHash("Roll");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Init(float damageAmount)
    {
        _spawnTime = Time.time;
        _currentY = transform.position.y;
        _damageAmount = damageAmount;
    }

    private void Update()
    {
        if(Time.time - _spawnTime > 1f && !_finishRoll)
        {
            RollDice();
        }
    }

    private void RollDice()
    {
        _time += Time.deltaTime;
        float progress = _time / _rollDuration;

        float yPos = Mathf.Lerp(_currentY, _currentY - _dropDistance, EaseOutBounce(progress)) * _power;

        Vector3 pos = transform.position;
        pos.y = yPos;
        transform.position = pos;

        if(progress >= 1f)
        {
            StartCoroutine(FinishRollCoroutine());
            return;
        }
    }

    private IEnumerator FinishRollCoroutine()
    {
        _finishRoll = true;
        _animator.enabled = false;
        int idx = Random.Range(0, _sprites.Count);
        _spriteRenderer.sprite = _sprites[idx];

        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < idx; i++)
        {
            var newBullet = PoolManager.Instance.Pop(_bulletType);
            Bullet bullet = newBullet as ReflectiveBullet;
            bullet.transform.position = transform.position;
            bullet.Init(bullet.RandomDir(), _damageAmount, true, 1f);
        }
        yield return new WaitForSeconds(1f);
        _myPool.Push(this);
    }

    public void SetUpPool(Pool pool)
    {
        _myPool = pool;
    }

    public void ResetItem()
    {
    }

    private float EaseOutBounce(float x)
    {
        const float n1 = 7.5625f;
        const float d1 = 2.75f;

        if (x < 1 / d1) 
        {
            return n1 * x * x;
        }
        else if (x < 2 / d1)
        {
            if (!_firstBounce)
            {
                _animator.SetTrigger(_rollTriggerHash);
                _firstBounce = true;
            }
            return n1 * (x -= 1.5f / d1) * x + 0.75f;
        }
        else if (x < 2.5 / d1)
        {
            return n1 * (x -= 2.25f / d1) * x + 0.9375f;
        }
        else
        {
            return n1 * (x -= 2.625f / d1) * x + 0.984375f;
        }
    }


}
