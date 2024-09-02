using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PlayerAttribute/PlayerStat")]
public class PlayerStatSO : PlayerAttributeSO, IPlayerComponent
{
    public float moveSpeed;
    public float attackDamage;
    public float attackSpeed;
    public float MaxHp;


    // 일단 안쓸거긴한데 혹시모르니까
    private Player _player;

    public void Initialize(Player player)
    {
        _player = player;    
    }
}
