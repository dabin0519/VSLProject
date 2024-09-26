using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSkill : MultiSkill
{
    [SerializeField] private float _angle;

    protected override void SetUpDamageVisual(int idx, int cnt)
    {
        ArrowSkillVisual arrowVisual = _damageList[idx] as ArrowSkillVisual;
        arrowVisual.Init(CalculateDirVector(idx, cnt));
    }

    private Vector3 CalculateDirVector(int idx, int cnt)
    {
        Vector3 mouseDir = GetMouseWorldPos() - GameManager.Instance.PlayerTrm.position;
        Vector3 startVector = Rotate(mouseDir, -_angle / 2); // angle 각의 2분의 1만큼 앞으로 땡긴 후 시작
        
        mouseDir.Normalize();

        float startAngle = _angle / (cnt + 1); // ex) cnt가 2면 3으로 나눠야 2개의 선이 나온다.

        Vector3 rotateVector = Rotate(startVector, startAngle * idx);

        return mouseDir;
    }

    public Vector3 Rotate(Vector3 target, float angle)
    {
        float radian = Mathf.Deg2Rad * angle;
        float cosTheta = Mathf.Cos(radian);
        float sinTheta = Mathf.Sin(radian);

        // 회전 행렬 이용해서 target 벡터를 angle만큼 회전시킨 벡터를 얻음
        return new Vector3(cosTheta * target.x - sinTheta * target.x, sinTheta * target.y + cosTheta * target.y); 
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        return mousePos;
    }
}
