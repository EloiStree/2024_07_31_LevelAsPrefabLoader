using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LoadLevelPrefabLoadOnClickMono : MonoBehaviour ,IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent m_onDown;
    public UnityEvent m_onUp;
    public void OnPointerDown(PointerEventData eventData)
    {
        m_onDown.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        m_onUp.Invoke();
        
    }

    public void OnMouseDown()
    {
        m_onDown.Invoke();
    }
    
    public void OnMouseUp()
    {
        m_onUp.Invoke();
    }
}
