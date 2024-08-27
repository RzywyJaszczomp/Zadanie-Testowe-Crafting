using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _amount;

    public void SetItemSlot(Sprite image, int amount)
    {
        Debug.Log(_image);
        _image.sprite = image;
        _amount.text = $"{amount}";
    }
}
