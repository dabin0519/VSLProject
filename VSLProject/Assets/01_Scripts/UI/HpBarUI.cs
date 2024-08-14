using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarUI : MonoBehaviour
{
    private Transform _currentHpTrm;

    private void Awake()
    {
        _currentHpTrm = transform.Find("CurrentHp");
    }

    public void UpdateUI(float hp, float maxHp)
    {
        _currentHpTrm.localScale = new Vector3(hp / maxHp, _currentHpTrm.localScale.y);
    }
}
