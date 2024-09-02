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


    // �ϴ� �Ⱦ��ű��ѵ� Ȥ�ø𸣴ϱ�
    private Player _player;

    public void Initialize(Player player)
    {
        _player = player;    
    }
}
