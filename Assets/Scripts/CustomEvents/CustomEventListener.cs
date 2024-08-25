using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomEventListener : MonoBehaviour
{
    [SerializeField]
    private CustomEvent m_event;
    [SerializeField]
    private UnityEvent<GameObject> m_reaction;
    private void OnEnable()
    {
        m_event.RegisterListener(this);
    }
    private void OnDisable()
    {
       m_event.DeregisterListener(this); 
    }

    public void OnEvent(GameObject gameObject)
    {
        m_reaction.Invoke(gameObject);
    }


}
