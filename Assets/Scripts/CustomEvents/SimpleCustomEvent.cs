using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SimpleCustomEvent", menuName = "ScriptableObjects/Events/SimpleCustomEvent")]
public class SimpleCustomEvent : ScriptableObject
{
    [Header("Visible for Debug")]
    [SerializeField]
    private List<SimpleCustomEventListener> m_listeners;

    public void RegisterListener(SimpleCustomEventListener listener)
    {
        m_listeners.Add(listener);
    }

    public void DeregisterListener(SimpleCustomEventListener listener)
    {
        m_listeners.Remove(listener);
    }

    public void Invoke()
    {
        for(int i = m_listeners.Count -1; i >= 0; --i)
        {
            m_listeners[i].OnEvent();
        }
    }
}
