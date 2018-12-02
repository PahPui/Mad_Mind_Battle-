using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.
using UnityEngine.Events;

public class OnButtonHover : MonoBehaviour, IPointerEnterHandler
{
    public UnityEvent OnHover;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("The cursor entered the selectable UI element.");
        OnHover.Invoke();
    }
}

