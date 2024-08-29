using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _amount;

    public void SetItemSlot(Sprite image, int amount)
    {
        _image.sprite = image;
        _amount.text = $"{amount}";
    }
}
