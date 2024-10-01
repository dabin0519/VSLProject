using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectiveBullet : Bullet
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Vector2 normal = collision.contacts[0].normal;
            Vector2 reflectionDir = Vector2.Reflect(_moveDir, normal);
            _moveDir = reflectionDir;
        }
    }
}
