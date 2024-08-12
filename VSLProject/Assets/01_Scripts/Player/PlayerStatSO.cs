using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PlayerStat")]
public class PlayerStatSO : ScriptableObject
{
    public float moveSpeed;
    public float attackDamage;
    public float attackSpeed;
    public float HP;
}
