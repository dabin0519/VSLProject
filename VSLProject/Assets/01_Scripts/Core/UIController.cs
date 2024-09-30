using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoSingleton<UIController>
{
    [SerializeField] private SkillSelectUI _skillSelectUI;
    [SerializeField] private InfoUI _infoUI;

    public InfoUI InfoUIProp => _infoUI;

    private void Start()
    {
        GameManager.Instance.GameStartEvent += SettingSelectUI;
        GameManager.Instance.Player.GetCompo<InputReader>().TabEvent += OnInfoPaenel;
    }

    private void OnInfoPaenel()
    {
        _infoUI.ShowInfoUI();
    }

    private void SettingSelectUI()
    {
        _skillSelectUI.gameObject.SetActive(true);
        _skillSelectUI.ShowSkillUI(true);
    }
}
