using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSkill : MultiSkill
{
    protected override void SetUpDamageVisual(int idx, int cnt)
    {
        CircleSkillVisual circleVisual = _damageList[idx] as CircleSkillVisual;
        circleVisual.OnSkill(_playerTrm, 360 / cnt * idx);
    }
}
