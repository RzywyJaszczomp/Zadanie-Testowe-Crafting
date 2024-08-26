using System.Collections.Generic;
using UnityEngine;

public class GenericCustomEvent<T> : ScriptableObject
{
    [Header("Visible for Debug")]
    [SerializeField]
    private List<GenericCustomEventListener<T>> m_listeners;

    public void RegisterListener(GenericCustomEventListener<T> listener)
    {
        m_listeners.Add(listener);
    }

    public void DeregisterListener(GenericCustomEventListener<T> listener)
    {
        m_listeners.Remove(listener);
    }

    public void Invoke(T arg)
    {
        for(int i = m_listeners.Count -1; i >= 0; --i)
        {
            m_listeners[i].OnEvent(arg);
        }
    }
}