using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOEvent", menuName = "ScriptableObjects/SOEvent")]
public class CustomEvent : ScriptableObject
{
    [Header("Visible for Debug")]
    [SerializeField]
    private List<CustomEventListener> m_listeners;

    public void RegisterListener(CustomEventListener listener)
    {
        m_listeners.Add(listener);
    }

    public void DeregisterListener(CustomEventListener listener)
    {
        m_listeners.Remove(listener);
    }

    public void Invoke(GameObject gameObject)
    {
        for(int i = m_listeners.Count -1; i >= 0; --i)
        {
            m_listeners[i].OnEvent(gameObject);
        }
    }
}
