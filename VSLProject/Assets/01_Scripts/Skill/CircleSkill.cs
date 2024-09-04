using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSkill : Skill
{
    [SerializeField] private CircleSkillVisual _circleSkillPrefab;
    [SerializeField] private List<CircleSkillVisual> _visualList;

    protected override void Update()
    {
        base.Update();

        if(Input.GetMouseButtonDown(0))
        {
            OnSkill();
        }
        if(Input.GetMouseButtonDown(1))
        {
            SkillLevelUP();
        }
    }

    public override void OnSkill()
    {
        base.OnSkill();

        int cnt = _visualList.Count;
        for(int i = 0; i < cnt; ++i)
        {
            _visualList[i].gameObject.SetActive(true);
            _visualList[i].OnSkill(_playerTrm, 360 / cnt * i);
        }
    }

    public override void SkillLevelUP()
    {
        CircleSkillVisual newSkillVisual = Instantiate(_circleSkillPrefab, transform);
        _visualList.Add(newSkillVisual);
        newSkillVisual.gameObject.SetActive(false);
    }

    public override void OffSkill()
    {
        foreach(var visual in _visualList)
        {
            visual.OffSkill();
        }
    }
}
