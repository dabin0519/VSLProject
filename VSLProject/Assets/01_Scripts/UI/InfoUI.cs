using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoUI : MonoBehaviour
{
    [SerializeField] private List<SkillContainerUI> _skillUIList;
    [SerializeField] private List<TextMeshProUGUI> _statIncreaseTexts; // 체력, 공격, 속도, 방어, 범위, 쿨다운, 지속시간, 경험치
    [SerializeField] private float _showTweenDuration;

    private Dictionary<Sprite, SkillContainerUI> _skillUIDictionary;
    private RectTransform _rectTransform;

    private int _index;
    private bool _showUI;

    private void Awake()
    {
        _skillUIDictionary = new Dictionary<Sprite, SkillContainerUI>();

        _rectTransform = transform.Find("UIParent").GetComponent<RectTransform>();
    }

    public void SkillUIInit(Sprite icon)
    {
        _skillUIList[_index].Init(icon);
        _skillUIDictionary.Add(icon, _skillUIList[_index]);

        _index++;
    }

    public void SkillUILevelUP(Sprite icon)
    {
        _skillUIDictionary[icon].LevelUP();
    }

    public void ShowInfoUI()
    {
        _showUI = !_showUI;

        float posX = _showUI ? 200f : -500f;

        _rectTransform.DOAnchorPosX(posX, _showTweenDuration);
    }

    public void UpdateStatUI(PlayerStatSO defaultStat, PlayerStatSO currentStat)
    {
        foreach(StatType type in System.Enum.GetValues(typeof(StatType)))
        {
            float defaultValue = defaultStat.GetStatValue(type);
            float currentValue = currentStat.GetStatValue(type);
            float difference = currentValue - defaultValue;

            if (difference > 0)
            {
                _statIncreaseTexts[(int)type].text = $"+{difference}";
            }
            else if (difference < 0)
            {
                _statIncreaseTexts[(int)type].text = $"{difference}";
            }
            else
            {
                _statIncreaseTexts[(int)type].text = "-";
            }
        }
    }
}
