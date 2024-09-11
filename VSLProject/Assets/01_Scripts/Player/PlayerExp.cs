using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    [SerializeField] private PlayerExpSO _playerExpSO;
    [SerializeField] private ExpBarUI _expBarUI;

    private List<float> _needExpAmountList;
    public float currentExp;

    private void Awake()
    {
        _needExpAmountList = _playerExpSO.needExpAmountList;
    }

    private void Start()
    {
        _expBarUI.UpdateUI(currentExp, _needExpAmountList[0], 1);
    }

    private void Update()
    {
        CalculateCurrentLevel();
    }

    private void CalculateCurrentLevel()
    {
        for(int i = 0; i < _needExpAmountList.Count; ++i)
        {
            if(currentExp < _needExpAmountList[i])
            {
                // 현재 레벨보다 낮다 
                float exp = currentExp;
                if(i != 0)
                {
                    exp = currentExp - _needExpAmountList[i - 1];
                }
                _expBarUI.UpdateUI(currentExp, _needExpAmountList[i], i + 1);
                break;
            }
        }
    }
}
