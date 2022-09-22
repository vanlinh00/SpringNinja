
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAni : Selectable
{
    //Use this to check what Events are happening
    BaseEventData m_BaseEvent;

    void Update()
    {
        ////Check if the GameObject is being highlighted
        //if (IsHighlighted(m_BaseEvent))
        //{
        //    //Output that the GameObject was highlighted, or do something else
        //    Debug.Log("Selectable is Highlighted");
        //}
    }
}
