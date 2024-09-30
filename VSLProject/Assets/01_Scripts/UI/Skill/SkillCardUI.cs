using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SkillCardUI : MonoBehaviour // 스킬 icon 이름 설명등을 관리하는 UI 하지만 이 친구는
                                         // 단순 그냥 보여주는 용도임 그 이외에 코드는 다른 controller에다가 ㄱㄱ
{
    [SerializeField] private float _duration;

    private Image _skillIcon;
    private TextMeshProUGUI _skillName;
    private TextMeshProUGUI _skillDescription;
    private RectTransform _rectTransform;
    private Attribute _attribute;

    public Attribute attribute => _attribute;

    private void Awake()
    {
        _skillIcon = transform.Find("Icon").GetComponent<Image>();
        _skillName = transform.Find("Name").GetComponent<TextMeshProUGUI>();
        _skillDescription = transform.Find("Description").GetComponent<TextMeshProUGUI>();
        _rectTransform = GetComponent<RectTransform>();
    }

    public void ShowUI(Attribute attribute)
    {
        _attribute = attribute;

        AttributeInfo info = attribute.attributeSO.AttributeInfo;

        _skillIcon.sprite = info.icon;
        _skillName.text = info.name;
        _skillDescription.text = info.description;
    }

    public void ClearUI()
    {
        _skillIcon.sprite = null;
        _skillName.text = "";
        _skillDescription.text = "";
    }
}
