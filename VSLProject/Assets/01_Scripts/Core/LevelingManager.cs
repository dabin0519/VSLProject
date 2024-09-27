using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelingManager : MonoSingleton<LevelingManager>
{
    [SerializeField]
    [Tooltip("�׳� ū �� �־� ���⼭ ���̽��� �̾Ƽ� Ȯ�� ����Ұ���")]
    private int _baseRandomNum;

    // ���߿� ���� Sheet�� �����ؼ� ���� �ִ� ������ googleSheet���� �ܾ���� �� ����

    public int GetRandomIdx(int maxCnt)
    {
        //int randomNum = Random.Range(0, _baseRandomNum);

        return Random.Range(0, maxCnt);
    }
}
