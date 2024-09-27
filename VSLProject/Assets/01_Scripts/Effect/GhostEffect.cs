using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEffect : MonoBehaviour
{
    [SerializeField] private float _ghostDelay;
    [SerializeField] private PoolTypeSO _ghostType;

    public bool spawnGhost;

    private SpriteRenderer _playerSpriteRenderer;
    private float _ghostDelaySeconds;

    private void Awake()
    {
        _playerSpriteRenderer = transform.Find("Visual").GetComponent<SpriteRenderer>();

        _ghostDelaySeconds = _ghostDelay;
    }

    private void Update()
    {
        if (!spawnGhost)
            return;

        if (_ghostDelaySeconds > 0)
        {
            _ghostDelaySeconds -= Time.deltaTime;
        }
        else
        {
            var ghost = PoolManager.Instance.Pop(_ghostType);
            Sprite currentSprite = _playerSpriteRenderer.sprite;
            ghost.GameObject.transform.position = transform.position;
            ghost.GameObject.GetComponent<SpriteRenderer>().sprite = currentSprite;
            ghost.GameObject.GetComponent<SpriteRenderer>().flipX = _playerSpriteRenderer.flipX;
            _ghostDelaySeconds = _ghostDelay;
        }
    }
}
