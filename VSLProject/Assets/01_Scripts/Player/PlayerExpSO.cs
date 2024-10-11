using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Player/ExpInfo")]
public class PlayerExpSO : ScriptableObject
{
    public List<float> needExpAmountList = new List<float>();
}
