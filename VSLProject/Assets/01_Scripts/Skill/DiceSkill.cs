using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSkill : SpawnSkill
{
    public override void InitObject(GameObject newObj)
    {
        newObj.transform.position = _playerTrm.position;
        newObj.GetComponent<DiceSkillVisual>().Init(_damageAmount);
    }

    public override void OffSkill()
    {

    }

    public override void SkillLevelUP()
    {
        
    }
}
