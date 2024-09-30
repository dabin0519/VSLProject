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

        _playerDefaultStat.InitDictionary();
        _playerStat = Instantiate(_playerDefaultStat);
        _playerStat.InitDictionary();
    }

    public void ModifierStat(PlayerStatSO statSO) 
    {
        _playerStat += statSO;
        _playerStat.UpdateStatDictionary();
        UIController.Instance.InfoUIProp.UpdateStatUI(_playerDefaultStat, _playerStat);
    }

    // StatClone�� ���� Modifier ����� ������
    // �� clone�� ����� �ϰ� �� ������ ��� �ְ�?
}
