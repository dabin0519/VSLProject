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
        Vector3 startVector = Rotate(mouseDir, -_angle / 2); // angle ���� 2���� 1��ŭ ������ ���� �� ����
        
        mouseDir.Normalize();

        float startAngle = _angle / (cnt + 1); // ex) cnt�� 2�� 3���� ������ 2���� ���� ���´�.

        Vector3 rotateVector = Rotate(startVector, startAngle * idx);

        return mouseDir;
    }

    public Vector3 Rotate(Vector3 target, float angle)
    {
        float radian = Mathf.Deg2Rad * angle;
        float cosTheta = Mathf.Cos(radian);
        float sinTheta = Mathf.Sin(radian);

        // ȸ�� ��� �̿��ؼ� target ���͸� angle��ŭ ȸ����Ų ���͸� ����
        return new Vector3(cosTheta * target.x - sinTheta * target.x, sinTheta * target.y + cosTheta * target.y); 
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        return mousePos;
    }
}
