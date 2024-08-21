using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillCardUI : MonoBehaviour // 스킬 icon 이름 설명등을 관리하는 UI 하지만 이 친구는
                                         // 단순 그냥 보여주는 용도임 그 이외에 코드는 다른 controller에다가 ㄱㄱ
{
    private Image _skillIcon;
    private TextMeshProUGUI _skillName;
    private TextMeshProUGUI _skillDescription;

    private void Awake()
    {
        _skillIcon          = transform.Find("Icon").GetComponent<Image>();
        _skillName          = transform.Find("Name").GetComponent<TextMeshProUGUI>();
        _skillDescription   = transform.Find("Description").GetComponent<TextMeshProUGUI>();
    }

    public void ShowUI(Sprite icon, string name, string description)
    {
        _skillIcon.sprite = icon;
        _skillName.text = name;
        _skillDescription.text = description;
    }
}
