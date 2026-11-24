using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailsPanel : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text itemQtyText;
    [SerializeField] private TMP_Text itemDescriptionText;

    public void Show(ItemDetails item, int quantity)
    {
        if (item == null)
        {
            Clear();
            return;
        }
        itemImage.sprite = item.ItemSprite;
        itemImage.enabled = true;
        itemNameText.text = item.ItemName;
        itemQtyText.text = "Qty: " + quantity;
        itemDescriptionText.text = item.Description;
    }
    public void Clear()
    {
        itemImage.sprite = null;
        itemImage.enabled = false;
        itemNameText.text = "";
        itemQtyText.text = "";
        itemDescriptionText.text = "";
    }
}
