using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PlayerAttribute/PlayerStat")]
public class PlayerStatSO : PlayerAttributeSO
{
    public float moveSpeed;
    public float attackDamage;
    public float attackSpeed;
    public float MaxHp;

    public static PlayerStatSO operator+(PlayerStatSO value1, PlayerStatSO value2)
    {
        value1.moveSpeed += value2.moveSpeed;
        value1.attackDamage += value2.attackDamage;
        value1.attackSpeed += value2.attackSpeed;
        value1.MaxHp += value2.MaxHp;

        // 추가로 달면 더 ㄱㄱ

        return value1;
    }
}
