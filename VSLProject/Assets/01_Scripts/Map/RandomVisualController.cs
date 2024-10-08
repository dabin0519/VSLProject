using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVisualController : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        VisualInit();
    }

    private void VisualInit()
    {
        Sprite sprite = _sprites[GetRandomIdx()];

        _spriteRenderer.sprite = sprite;
    }

    private int GetRandomIdx()
    {
        int rNum = Random.Range(0, _sprites.Length);
        return rNum;
    }
}
