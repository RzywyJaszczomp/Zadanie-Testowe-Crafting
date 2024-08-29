using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    private CustomItemEvent _requestItemRemovedE;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _amount;

    private Item _containedItem;

    public void ConfigureSlot(CustomItemEvent itemRemovedE)
    {
        _image.gameObject.SetActive(false);
        _requestItemRemovedE = itemRemovedE;
    }
    
    public void SetItemIcon(Item item, int amount)
    {
        _containedItem = item;
        _image.sprite = item.Icon;
        _amount.text = $"{amount}";
        _image.gameObject.SetActive(true);
    }

    public void ResetIcon()
    {
        _image.gameObject.SetActive(false);
    }

    public void RequestRemovalFromSlot()
    {
        _requestItemRemovedE.Invoke(_containedItem);
    }
}
