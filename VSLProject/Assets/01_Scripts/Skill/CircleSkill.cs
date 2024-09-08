using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSkill : Skill
{
    [SerializeField] private CircleSkillVisual _circleSkillPrefab;
    [SerializeField] private List<CircleSkillVisual> _visualList;

    public override void OnSkill()
    {
        base.OnSkill();

        int cnt = _visualList.Count;

        if(cnt == 0)
        {
            SpawnVisual();
        }

        for(int i = 0; i < cnt; ++i)
        {
            _visualList[i].gameObject.SetActive(true);
            _visualList[i].OnSkill(_playerTrm, 360 / cnt * i);
        }
    }

    private void SpawnVisual()
    {
        CircleSkillVisual newSkillVisual = Instantiate(_circleSkillPrefab, transform);
        _visualList.Add(newSkillVisual);
        newSkillVisual.gameObject.SetActive(false);
    }

    public override void SkillLevelUP()
    {
        SpawnVisual();
    }

    public override void OffSkill()
    {
        foreach(var visual in _visualList)
        {
            visual.OffSkill();
        }
    }
}
