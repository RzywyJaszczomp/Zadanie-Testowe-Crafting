using UnityEngine;
using UnityEngine.Events;

public class SimpleCustomEventListener : MonoBehaviour
{
    [SerializeField]
    private SimpleCustomEvent m_event;
    [SerializeField]
    private UnityEvent m_reaction;
    private void OnEnable()
    {
        m_event.RegisterListener(this);
    }
    private void OnDisable()
    {
       m_event.DeregisterListener(this); 
    }

    public void OnEvent()
    {
        m_reaction.Invoke();
    }
}