using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private SkillSelectUI _skillSelectUI;

    private void Awake()
    {
        GameManager.Instance.GameStartEvent += SettingSelectUI;
    }

    private void SettingSelectUI()
    {
        _skillSelectUI.gameObject.SetActive(true);
        _skillSelectUI.ShowSkillUI(true);
    }
}
