using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attribute : MonoBehaviour
{
    public int level => _level;
    [SerializeField] private int _level;

    public int maxLevel = 5;
    public PlayerAttributeSO attributeSO;  

    public virtual void LevelUp()
    {
        _level++;
        if(_level >= maxLevel)
        {
            _level = maxLevel;
            return;
        }
    }
}
