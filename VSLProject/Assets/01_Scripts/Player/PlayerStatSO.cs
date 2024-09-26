using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PlayerAttribute/PlayerStat")]
public class PlayerStatSO : PlayerAttributeSO
{
    public float moveSpeed;
    public float attackDamage;
    public float MaxHp;
    public float depense;
    public float attackRange;
    public float timeAccelration;       // �����Ҽ��� ��Ÿ�� �ش�
    public float skillDuration;         // �����Ҽ��� ��ų ���ӽð� ����
    public float expMultiplier;         // ����ġ ȹ�淮 ����

    public static PlayerStatSO operator+(PlayerStatSO value1, PlayerStatSO value2)
    {
        value1.moveSpeed        += value2.moveSpeed;
        value1.attackDamage     += value2.attackDamage;
        value1.MaxHp            += value2.MaxHp;
        value1.depense          += value2.depense;
        value1.attackRange      += value2.attackRange;
        value1.timeAccelration  += value2.timeAccelration;
        value1.skillDuration    += value2.skillDuration;  
        value1.expMultiplier    += value2.expMultiplier;

        return value1;
    }
}
