using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class SkillSelectUI : MonoBehaviour // skillSelectPenel ��ü�� �����ϴ� ģ��
{
    [SerializeField] private SkillSelectSO _skillSelectSO;
    [SerializeField] private float _duration;
    [SerializeField] private PlayerExp _playerExp;

    private List<SkillCardUI> _cardList;
    [SerializeField] private List<int> _cardIdxList = new List<int>();

    private RectTransform _backGroundRectTrm;
    private bool _isFirstTime; // ���� ���۽� ���ȶ߸� ���ϴϱ� ��ų�� �߰��ϱ� ���� ����
    private List<Attribute> _attributeList;

    private void Awake()
    {
        _backGroundRectTrm = transform.Find("Background").GetComponent<RectTransform>();
        _cardList = transform.GetComponentsInChildren<SkillCardUI>().ToList();

        _backGroundRectTrm.localPosition = new Vector3(0, -1000);

        _attributeList = _skillSelectSO.attributeList;

        _isFirstTime = true;
    }

    private Attribute RandomAttribute()
    {
        int randomIdx;
        do
        {
            randomIdx = Random.Range(0, _attributeList.Count);
        }
        // ���� �Ӽ��� �̾Ҵµ� ���� �Ӽ��� �ְ����̸� �ƴҶ����� ���� 
        while (CheckFirstTime(randomIdx) || _attributeList[randomIdx].level >= _attributeList[randomIdx].maxLevel || IsDuplication(randomIdx));

        _cardIdxList.Add(randomIdx);
        return _attributeList[randomIdx];
    }

    private bool CheckFirstTime(int randomIdx)
    {
        if(_isFirstTime && _attributeList[randomIdx] is not Skill)
        {
            return true;
        }
        return false;
    }

    private bool IsDuplication(int randomIdx) // ���࿡ ��ġ�°� ������ return true
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
                //AttributeInfo attributeInfo = attribute.attributeSO.AttributeInfo;
                _cardList[i].ShowUI(attribute);
            }
            else
            {
                _cardList[i].ClearUI();
            }
        }

        if(_isFirstTime) 
            _isFirstTime = false;

        _backGroundRectTrm.DOLocalMoveY(posY, _duration).SetUpdate(true)
            .OnComplete(() => 
            {
                if(value == false)
                {
                    GameManager.Instance.DelayTime(0.2f, () => _playerExp.CanLevelUP());
                }
            });
    }
}
