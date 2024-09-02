using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class SkillSelectUI : MonoBehaviour // skillSelectPenel ��ü�� �����ϴ� ģ��
{
    [SerializeField] private List<Attribute> _attributeList;
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

    private Attribute RandomAttribute()
    {
        int randomIdx;
        do
        {
            randomIdx = Random.Range(0, _attributeList.Count);
        }
        while (_attributeList[randomIdx].level >= _attributeList[randomIdx].maxLevel || IsDuplication(randomIdx)); // ���� �Ӽ��� �̾Ҵµ� ���� �Ӽ��� �ְ������̸� �ƴҶ����� ����

        _cardIdxList.Add(randomIdx);
        return _attributeList[randomIdx];
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
        float posY = value ? 0 : -1000;
        
        if(value)
        {
            _cardIdxList.Clear();
        }

        //_backGroundRectTrm.DOLocalMoveY(posY, _duration).OnComplete(() =>
        {
            for(int i = 0; i < 3; ++i)
            {
                if(value)
                {
                    AttributeInfo attributeInfo = RandomAttribute().attributeSO.Attribute;
                    _cardList[i].ShowUI(attributeInfo.icon, attributeInfo.name, attributeInfo.description);
                }
                else
                {
                    _cardList[i].ClearUI();
                }
            }
        }//);
    }
}