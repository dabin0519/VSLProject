using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEffect : MonoBehaviour
{
    [SerializeField] private float _ghostDelay;
    [SerializeField] private GameObject _ghostObject;
    [SerializeField] private float _ghostDuration;

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
            GameObject currentGhost = Instantiate(_ghostObject, transform.position, transform.rotation);
            Sprite currentSprite = _playerSpriteRenderer.sprite;
            currentGhost.GetComponent<SpriteRenderer>().sprite = currentSprite;
            currentGhost.GetComponent<SpriteRenderer>().flipX = _playerSpriteRenderer.flipX;
            _ghostDelaySeconds = _ghostDelay;
            Destroy(currentGhost, _ghostDuration);
        }
    }
}
