using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DBIntro : MonoBehaviour
{
    [SerializeField] private float _trmTweenDuration; // 이 오브젝트 tween 지속 시간
    [SerializeField] private float _backTextChangeDuration; // 백 텍스트 변환 시간
    [SerializeField] private float _backTextAlphaTarget; // 백 텍스트 최종 알파값
    [SerializeField] private float _backTextAlphaChangeDuration; // 백 텍스트 알파 변환 시간
    [SerializeField] private float _dbTextAlphaChangeDuration; // 백 텍스트 알파 변환 시간

    private RectTransform _dbParentTransform;
    private Image _circleImage;
    private TextMeshProUGUI _backText;
    private TextMeshProUGUI _dbText;

    private void Awake()
    {
        _dbParentTransform = GetComponent<RectTransform>();
        _circleImage = transform.Find("CircleImage").GetComponent<Image>();
        _backText = transform.Find("BackText").GetComponent<TextMeshProUGUI>();
        _dbText = transform.Find("DBText").GetComponent<TextMeshProUGUI>();

        _backText.text = "?";
        _backText.gameObject.SetActive(false);
        _dbText.gameObject.SetActive(false);
        _dbText.alpha = 0;
        _dbParentTransform.position = new Vector3(0, 500, 0);
    }

    private void Start()
    {
        StartTween();
    }

    public void StartTween() // 얘를 호출하면 시작 됩니다. 
    {
        _dbParentTransform.DOMoveY(0, _trmTweenDuration).SetEase(Ease.OutBounce)
            .OnComplete(() =>
            {
                _backText.gameObject.SetActive(true);
                DOVirtual.DelayedCall(_backTextChangeDuration, () =>
                {
                    _backText.text = "!";
                }).OnComplete(() =>
            {
                _backText.DOFade(_backTextAlphaTarget, _backTextAlphaChangeDuration)
                .OnComplete(() =>
                {
                    _dbText.gameObject.SetActive(true);
                    _dbText.DOFade(1, _dbTextAlphaChangeDuration);
                });
            });
            });
    }
}
