using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EnemySpriteInfo
{
    public Sprite sprite;
    public float scale;
}

public class EnemyVisualController : MonoBehaviour
{
    [SerializeField] private List<EnemySpriteInfo> _enemySpriteInfo;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        VisualInit();
    }

    private void VisualInit()
    {
        EnemySpriteInfo enemySpriteInfo = _enemySpriteInfo[GetRandomIdx()];

        _spriteRenderer.sprite = enemySpriteInfo.sprite;
        transform.localScale = new Vector3(enemySpriteInfo.scale, enemySpriteInfo.scale);
    }

    public void InitColor()
    {
        _spriteRenderer.color = Color.white;
    }

    private int GetRandomIdx()
    {
        int rNum = Random.Range(0, _enemySpriteInfo.Count);
        return rNum;
    }

    public void Flip(bool value)
    {
        _spriteRenderer.flipX = value;
    }
}
