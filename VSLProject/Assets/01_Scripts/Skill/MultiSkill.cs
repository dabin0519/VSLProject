using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MultiSkill : Skill
{
    [SerializeField] protected List<Damage> _damageList;
    [SerializeField] protected Damage _damagePrefab;

    public bool SpawnTransform;

    public override void OnSkill()
    {
        base.OnSkill();

        int cnt = _damageList.Count;

        if (cnt == 0)
        {
            SpawnPrefab();
        }

        for (int i = 0; i < cnt; ++i)
        {
            _damageList[i].gameObject.SetActive(true);
            SetUpDamageVisual(i, cnt);
        }
    }

    protected abstract void SetUpDamageVisual(int idx, int cnt);

    private void SpawnPrefab()
    {
        Damage newDamage;
        if (SpawnTransform)
        {
            newDamage = Instantiate(_damagePrefab, transform);
        }
        else
        {
            newDamage= Instantiate(_damagePrefab);
        }
        _damageList.Add(newDamage);
        newDamage.gameObject.SetActive(false);
    }

    public override void OffSkill()
    {
        foreach (var visual in _damageList)
        {
            visual.OffSkill();
        }
    }

    public override void SkillLevelUP()
    {
        SpawnPrefab();
    }
}
