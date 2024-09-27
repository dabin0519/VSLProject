using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DBIntro : MonoBehaviour
{
    [SerializeField] private float _trmTweenDuration; // �� ������Ʈ tween ���� �ð�
    [SerializeField] private float _backTextChangeDuration; // �� �ؽ�Ʈ ��ȯ �ð�
    [SerializeField] private float _backTextAlphaTarget; // �� �ؽ�Ʈ ���� ���İ�
    [SerializeField] private float _backTextAlphaChangeDuration; // �� �ؽ�Ʈ ���� ��ȯ �ð�
    [SerializeField] private float _dbTextAlphaChangeDuration; // �� �ؽ�Ʈ ���� ��ȯ �ð�

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

    public void StartTween() // �긦 ȣ���ϸ� ���� �˴ϴ�. 
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
