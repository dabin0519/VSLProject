using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillSelectUI : MonoBehaviour // skillSelectPenel ��ü�� �����ϴ� ģ��
{
    private List<SkillCardUI> _cardList;

    private void Awake()
    {
        _cardList = transform.GetComponentsInChildren<SkillCardUI>().ToList();
    }

    public void ShowSkillUI()
    {
        for(int i = 0; i < 3; ++i)
        {
            PlayerAttribute playerAttribute = RandomAttributeSystem.Instance.RandomAttribute();

            //_cardList[i].ShowUI();
        }
    }
}
