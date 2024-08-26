using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericCustomEventListener<T> : MonoBehaviour
{
    [SerializeField]
    private GenericCustomEvent<T> m_event;
    [SerializeField]
    private UnityEvent<T> m_reaction;
    private void OnEnable()
    {
        m_event.RegisterListener(this);
    }
    private void OnDisable()
    {
       m_event.DeregisterListener(this); 
    }

    public void OnEvent(T gameObject)
    {
        m_reaction.Invoke(gameObject);
    }


}
