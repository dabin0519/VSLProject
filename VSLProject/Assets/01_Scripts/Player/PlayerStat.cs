using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour, IPlayerComponent
{
    [SerializeField] private PlayerStatSO _playerDefaultStat;   // 기본 초기 스탯
    [SerializeField] private PlayerStatSO _playerStat;          // 진짜 스탯

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

    // StatClone을 만들어서 Modifier 기능이 들어오면
    // 그 clone에 기록을 하고 그 값들을 들고 있게?
}
