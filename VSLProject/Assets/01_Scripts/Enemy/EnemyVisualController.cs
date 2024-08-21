using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisualController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Flip(bool value)
    {
        _spriteRenderer.flipX = value;
    }
}
