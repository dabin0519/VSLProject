using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Events;

public abstract class ButtonController : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public UnityEvent OnClick;

    protected virtual void Awake()
    {

    }

    protected virtual void Update()
    {

    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        Click();
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        
    }

    public virtual void Click()
    {
        OnClick?.Invoke();
    }
}
