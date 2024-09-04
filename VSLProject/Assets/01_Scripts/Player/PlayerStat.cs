using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour, IPlayerComponent
{
    [SerializeField] private PlayerStatSO _playerDefaultStat;   // �⺻ �ʱ� ����
    [SerializeField] private PlayerStatSO _playerStat;          // ��¥ ����

    private Player _player;

    public PlayerStatSO PlayerStatProperty => _playerStat;

    public void Initialize(Player player)
    {
        _player = player;

        Init();
    }

    private void Init()
    {
        _playerStat = Instantiate(_playerDefaultStat); 
    }

    public void ModifierStat(PlayerStatSO statSO) 
    {
        _playerStat += statSO;
    }

    // StatClone�� ���� Modifier ����� ������
    // �� clone�� ����� �ϰ� �� ������ ��� �ְ�?
}
