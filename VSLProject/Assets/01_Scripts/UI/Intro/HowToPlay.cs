using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class HowToPlay : ButtonController
{
    [SerializeField] private float _scaleValue;
    [SerializeField] private float _duration;

    private Vector3 _currentScale;
    private RectTransform _rectTransform;

    protected override void Awake()
    {
        base.Awake();

        _rectTransform = GetComponent<RectTransform>();
        _currentScale = _rectTransform.localScale;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (_rectTransform != null)
            _rectTransform.DOScale(_currentScale * _scaleValue, _duration);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        if (_rectTransform != null)
            _rectTransform.DOScale(_currentScale, _duration);
    }
}
