using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExp : MonoBehaviour, IPlayerComponent
{
    [SerializeField] private PlayerExpSO _playerExpSO;
    [SerializeField] private ExpBarUI _expBarUI;
    [SerializeField] private SkillSelectUI _skillSelectUI;

    private List<float> _needExpAmountList;
    private PlayerStatSO _playerStatSO;
    private float _currentExp;
    private float _needExp;
    private float _beforeNeedExp; // UI 보정 위해서 
    private int _idx;
    private bool _canLevelUP;

    public void Initialize(Player player)
    {
        PlayerStat playerStat = player.GetCompo<PlayerStat>();

        _playerStatSO = playerStat.PlayerStatProperty;

        _needExpAmountList = _playerExpSO.needExpAmountList;
        _needExp = _needExpAmountList[0];
        _beforeNeedExp = 0;
        _idx = 0;
        _canLevelUP = true;
    }

    private void Update()
    {
        _expBarUI.UpdateUI(_currentExp - _beforeNeedExp, _needExp - _beforeNeedExp, _idx + 1);
        CalculateValue();
    }

    private void CalculateValue()
    {
        if(_currentExp >= _needExp && _canLevelUP)
        {
            ++_idx;
            if(_idx == _needExpAmountList.Count) // 인덱스를 넘어갔을경우
            {
                _expBarUI.MaxLevelUI();
            }
            else
            {
                LevelUP();
            }
        }
    }

    private void LevelUP()
    {
        _canLevelUP = false;
        _beforeNeedExp = _needExp;
        _needExp = _needExpAmountList[_idx];
        _skillSelectUI.ShowSkillUI(true);
    }

    public void IncreaseExp(float expAmount)
    {
        _currentExp += expAmount * _playerStatSO.expMultiplier;
    }


    public void CanLevelUP()
    {
        _canLevelUP = true;
    }
}
