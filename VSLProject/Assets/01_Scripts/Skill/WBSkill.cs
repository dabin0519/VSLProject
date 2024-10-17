using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WBSkill : SpawnSkill
{
    [SerializeField] private float _range;

    public override void InitObject(GameObject newObj)
    {
        newObj.transform.position = transform.position;
        WBSkillVisual visual = newObj.GetComponent<WBSkillVisual>();
        visual.Init(_damageAmount, _range, _duration);
    }

    public override void OffSkill()
    {
        
    }

    public override void SkillLevelUP()
    {
        
    }
}
