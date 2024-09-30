using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSkillVisual : MonoBehaviour, IPoolable
{
    [SerializeField] private float _rollDuration;
    [SerializeField] private List<Sprite> _sprites;
    [field:SerializeField] public PoolTypeSO PoolType {  get; private set; }

    public GameObject GameObject => gameObject;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private float _spawnTime;

    private readonly int _rollTriggerHash = Animator.StringToHash("Roll");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Init();
    }

    public void Init()
    {
        _spawnTime = Time.time;
    }

    private void Update()
    {
        if(Time.time - _spawnTime > 1f)
        {
            RollDice();
        }
    }

    private void RollDice()
    {
        _animator.SetTrigger(_rollTriggerHash);
        transform.DOMoveY(-1, _rollDuration).SetEase(Ease.InBounce);
        _spriteRenderer.sprite = _sprites[Random.Range(0, _sprites.Count)];

    }

    public void SetUpPool(Pool pool)
    {
        
    }

    public void ResetItem()
    {
        
    }


}
