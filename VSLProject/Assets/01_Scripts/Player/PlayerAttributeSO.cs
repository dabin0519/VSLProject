using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AttributeInfo
{
    public Sprite icon;
    public string name;
    public string description;
}

public abstract class PlayerAttributeSO : ScriptableObject
{
    public AttributeInfo AttributeInfo;
}
