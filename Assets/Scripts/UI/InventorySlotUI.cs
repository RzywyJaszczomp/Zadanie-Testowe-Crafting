using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _amount;

    private void Awake()
    {
        _image.gameObject.SetActive(false);
    }
    
    public void SetItemIcon(Sprite sprite, int amount)
    {
        _image.sprite = sprite;
        _amount.text = $"{amount}";
        _image.gameObject.SetActive(true);
    }

    public void ResetIcon()
    {
        _image.gameObject.SetActive(false);
    }
}
