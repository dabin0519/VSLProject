using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class SkillSelectUI : MonoBehaviour // skillSelectPenel 자체를 관리하는 친구
{
    public List<Attribute> attributeList;
    [SerializeField] private float _duration;

    private List<SkillCardUI> _cardList;
    [SerializeField] private List<int> _cardIdxList = new List<int>();

    private RectTransform _backGroundRectTrm;
    private bool _isFirstTime; // 최초 시작시 스탯뜨면 망하니까 스킬만 뜨게하기 위한 변수

    private void Awake()
    {
        _backGroundRectTrm = transform.Find("Background").GetComponent<RectTransform>();
        _cardList = transform.GetComponentsInChildren<SkillCardUI>().ToList();

        _backGroundRectTrm.localPosition = new Vector3(0, -1000);

        _isFirstTime = true;
    }

    private Attribute RandomAttribute()
    {
        int randomIdx;
        do
        {
            randomIdx = Random.Range(0, attributeList.Count);
        }
        // 랜덤 속성을 뽑았는데 만약 속성에 최고레벨이면 아닐때까지 ㄱㄱ 
        while (CheckFirstTime(randomIdx) || attributeList[randomIdx].level >= attributeList[randomIdx].maxLevel || IsDuplication(randomIdx));

        _cardIdxList.Add(randomIdx);
        return attributeList[randomIdx];
    }

    private bool CheckFirstTime(int randomIdx)
    {
        if(_isFirstTime && attributeList[randomIdx] is not Skill)
        {
            return true;
        }
        return false;
    }

    private bool IsDuplication(int randomIdx) // 만약에 겹치는게 있으면 return true
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

        _backGroundRectTrm.DOLocalMoveY(posY, _duration).SetUpdate(true);
    }
}
