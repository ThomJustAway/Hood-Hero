using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ButtonMove : MonoBehaviour, IPointerExitHandler, IPointerDownHandler
{
    //ignore this, some reason it does cant work :(
    [SerializeField] private UnityEvent yourEvent;
    private bool isHolding = false;

    private void Update()
    {
        if (isHolding)
        {
            OnPointerDown();
        }
    }

    public void OnPointerDown()
    {
        yourEvent?.Invoke();
    }



    public void OnPointerExit(PointerEventData eventData)
    {
        isHolding = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
    }
}
