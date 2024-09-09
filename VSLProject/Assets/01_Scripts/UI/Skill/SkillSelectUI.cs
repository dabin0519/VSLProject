using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class SkillSelectUI : MonoBehaviour // skillSelectPenel ��ü�� �����ϴ� ģ��
{
    public List<Attribute> attributeList;
    [SerializeField] private float _duration;

    private List<SkillCardUI> _cardList;
    [SerializeField] private List<int> _cardIdxList = new List<int>();

    private RectTransform _backGroundRectTrm;

    private void Awake()
    {
        _backGroundRectTrm = transform.Find("Background").GetComponent<RectTransform>();
        _cardList = transform.GetComponentsInChildren<SkillCardUI>().ToList();

        _backGroundRectTrm.localPosition = new Vector3(0, -1000);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ShowSkillUI(true);
        }
    }

    private Attribute RandomAttribute()
    {
        int randomIdx;
        do
        {
            randomIdx = Random.Range(0, attributeList.Count);
        }
        while (attributeList[randomIdx].level >= attributeList[randomIdx].maxLevel || IsDuplication(randomIdx)); // ���� �Ӽ��� �̾Ҵµ� ���� �Ӽ��� �ְ����̸� �ƴҶ����� ����

        _cardIdxList.Add(randomIdx);
        return attributeList[randomIdx];
    }

    private bool IsDuplication(int randomIdx) // �ѹ� �ݺ��δ��? �����ϼž߰ڴµ�����?
    {
        if (_cardIdxList.Count != 0)
        {
            return _cardIdxList.Contains(randomIdx);
        }
        return false;
    }

    public void ShowSkillUI(bool value)
    {
        GameManager.Instance.GamePause(value);
        float posY = value ? 0 : -1000;
        
        if(value)
        {
            _cardIdxList.Clear();
        }

        for (int i = 0; i < 3; ++i)
        {
            if (value)
            {
                var attribute = RandomAttribute();
                AttributeInfo attributeInfo = attribute.attributeSO.AttributeInfo;
                _cardList[i].ShowUI(attributeInfo, attribute);
            }
            else
            {
                _cardList[i].ClearUI();
            }
        }
        _backGroundRectTrm.DOLocalMoveY(posY, _duration).SetUpdate(true);
    }
}
