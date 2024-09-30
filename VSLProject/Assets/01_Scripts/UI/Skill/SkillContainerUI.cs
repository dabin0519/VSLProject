using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SkillContainerUI : MonoBehaviour
{ 
    private Image _iconImage;
    private Transform _levelParent;
    private List<Image> _levelImageList;
    private int _imageIndex;

    private void Awake()
    {
        _iconImage = transform.Find("Icon").GetComponent<Image>();
        _levelParent = transform.Find("LevelParent");
        _levelImageList = _levelParent.GetComponentsInChildren<Image>().ToList();
    }

    public void Init(Sprite icon)
    {
        _iconImage.gameObject.SetActive(true);
        _iconImage.sprite = icon;
        LevelUP(); // 초기레벨 1로 시작
    }

    public void LevelUP()
    {
        _levelImageList[_imageIndex].color = Color.black; 
    }
}
