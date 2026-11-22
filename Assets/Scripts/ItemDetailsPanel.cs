using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailsPanel : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text itemQtyText;
    [SerializeField] private TMP_Text itemDescriptionText;
    
    public void Show(ItemDetails item)
    {
        if (item==null)
        {
            return;
        }
        itemImage.sprite = item.ItemSprite;
        itemNameText.text = item.ItemName;
        itemQtyText.text = "Qty: " + item.ItemQuantity;
        itemDescriptionText.text = item.Description;
    }
    public void Clear()
    {
        itemImage.sprite = null;
        itemImage.enabled = false;
        itemNameText.text="";
        itemQtyText.text = "";
        itemDescriptionText.text = "";
    }
}
