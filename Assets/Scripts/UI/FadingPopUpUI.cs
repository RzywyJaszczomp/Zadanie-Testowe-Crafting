using UnityEngine;
using System;
using TMPro;
using System.Collections;

public class FadingPopUpUI : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private String _message = "Picked up";
    [SerializeField] private float _secondsActive;
    private bool _isActive = false;
    private Coroutine _lastCoroutine = null; 

    public void SetText(GameObject interactable)
    {
        _text.text = $"{_message} {interactable.name}";
    }

    private void Start()
    {
        _panel.SetActive(false);
    }

    public void ActivateForSeconds()
    {
        if(_isActive)
        {
            StopCoroutine(_lastCoroutine);
        } 
            _isActive = true;
            _lastCoroutine = StartCoroutine(Show());
    }

    private IEnumerator Show()
    {
        _panel.SetActive(true);
        yield return new WaitForSeconds(_secondsActive);
        _panel.SetActive(false);
        _isActive = false;
    }

}
