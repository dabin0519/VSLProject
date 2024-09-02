using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SkillCardUI : MonoBehaviour // ��ų icon �̸� �������� �����ϴ� UI ������ �� ģ����
                                         // �ܼ� �׳� �����ִ� �뵵�� �� �̿ܿ� �ڵ�� �ٸ� controller���ٰ� ����
{
    [SerializeField] private float _duration;

    private Image _skillIcon;
    private TextMeshProUGUI _skillName;
    private TextMeshProUGUI _skillDescription;
    private RectTransform _rectTransform;

    private void Awake()
    {
        _skillIcon = transform.Find("Icon").GetComponent<Image>();
        _skillName = transform.Find("Name").GetComponent<TextMeshProUGUI>();
        _skillDescription = transform.Find("Description").GetComponent<TextMeshProUGUI>();
        _rectTransform = GetComponent<RectTransform>();
    }

    public void ShowUI(Sprite icon, string name, string description)
    {
        _skillIcon.sprite = icon;
        _skillName.text = name;
        _skillDescription.text = description;
    }

    public void ClearUI()
    {
        _skillIcon.sprite = null;
        _skillName.text = "";
        _skillDescription.text = "";
    }
}