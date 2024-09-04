using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButton : ButtonController
{
    [SerializeField] private PlayerAttribute _playerAttribute;

    private Attribute _attribute;

    protected override void Awake()
    {
        base.Awake();

    }

    public override void Click()
    {
        base.Click();

        _attribute = GetComponent<SkillCardUI>().attribute;
        _playerAttribute.AddAttribute(_attribute);
    }
}
