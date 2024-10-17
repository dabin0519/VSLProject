using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.PackageManager;
using UnityEngine;

public class WBSkillVisual : MonoBehaviour, IPoolable
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _distance;
    [SerializeField] private LayerMask _whatIsEnemy;
    [SerializeField] private float _rotateForce;
    [SerializeField] private float _pullForce;
    [SerializeField] private float _rotatePerSec;
    [SerializeField] private GameObject _effect;

    private Vector3 _moveDir;
    private Vector3 _spawnPos;
    private float _damage;
    private float _range;
    private float _duration;
    private float _spawnTime;
    private bool _finish;
    private List<RaycastHit2D> _hitInfoList;
    private List<RaycastHit2D> _prevHitInfoList;
    private bool _oneCall;

    [field:SerializeField] public PoolTypeSO PoolType { get; private set; }

    public GameObject GameObject => gameObject;

    public void Init(float damage, float range, float duration)
    {
        _hitInfoList = new List<RaycastHit2D>();
        _prevHitInfoList = new List<RaycastHit2D>();
        _oneCall = false;
        _finish = false;
        _spawnTime = Time.time;
        _spawnPos = transform.position;
        _damage = damage;
        _range = range;
        _duration = duration;
        _moveDir = GameManager.Instance.GetRandomDir();
    }

    private void FixedUpdate()
    {
        if (_finish) return;
        if (Vector2.Distance(_spawnPos, transform.position) < _distance)
        {
            transform.position += _moveDir * _moveSpeed * Time.fixedDeltaTime;
        }
        else
        {
            OnSkill();
            transform.Rotate(0, 0, _rotatePerSec * 360 * Time.fixedDeltaTime);

            if(!_oneCall)
            {
                _oneCall = true;
                GameObject gameObj = Instantiate(_effect, transform.position, Quaternion.identity);
                Destroy(gameObj, _duration - 0.5f);
            }
        }

        if (Time.time - _spawnTime > _duration)
        {
            _finish = true;

            GameManager.Instance.DelayTime(0.2f, () =>
            {
                foreach(var hitInfo in _hitInfoList)
                {
                    if (hitInfo.collider.TryGetComponent(out IDamageAble damageAble))
                    {
                        damageAble.GetDamage(_damage);
                    }
                    hitInfo.rigidbody.velocity = Vector2.zero;
                    hitInfo.rigidbody.angularVelocity = 0f;
                }
                PoolManager.Instance.Push(this);
            });
        }
    }


    private void OnSkill()
    {
        _hitInfoList = Physics2D.CircleCastAll(transform.position, _range, Vector2.zero, 0, _whatIsEnemy).ToList();

        foreach (var hitInfo in _hitInfoList)
        {
            Vector2 centerDir = (transform.position - hitInfo.transform.position).normalized;
            Vector2 rotationDir = new Vector2(-centerDir.y, centerDir.x);
            Vector2 force = centerDir * _pullForce + rotationDir * _rotateForce;
            hitInfo.rigidbody.AddForce(force * Time.fixedDeltaTime, ForceMode2D.Force);
        }

        _prevHitInfoList = new List<RaycastHit2D>(_hitInfoList);
    }

    public void ResetItem()
    {
        
    }

    public void SetUpPool(Pool pool)
    {
        
    }
}
