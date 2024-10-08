using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : Item
{
    [SerializeField] private float _healAmount;

    public override void ItemTrigger()
    {
        _player.GetCompo<PlayerHealth>().Heal(_healAmount);
    }
}
