using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    private void LateUpdate()
    {
        Debug.Log(Vector2.Distance(transform.position, ExpManager.Instance.playerTrm.position)); // 12이상 넘어가면? 삭제 ㄱㄱ
    }
}
