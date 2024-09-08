using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButton : ButtonController
{
    private PlayerAttribute _playerAttribute;

    private Attribute _attribute;
    private SkillCardUI _skillCardUI;

    protected override void Awake()
    {
        base.Awake();

        _skillCardUI = GetComponent<SkillCardUI>();
        _playerAttribute = FindObjectOfType<PlayerAttribute>();
    }

    public override void Click()
    {
        base.Click();

        _attribute = _skillCardUI.attribute;
        _playerAttribute.AddAttribute(_attribute);
    }
}
