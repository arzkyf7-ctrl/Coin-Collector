using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //item data
    public string itemName;
    public int itemQty;
    public Sprite itemSprite;
    public bool isFull;

    //item slot
    [SerializeField] private TMP_Text qtyText;
    [SerializeField] private Image itemImage;
    [SerializeField] private int MaxStackSize = 99;

    //selected item
    [SerializeField] public GameObject SelectedPanel;
    public bool isItemSelected;
    public InventoryManager inventoryManager;
    public ItemDetails ItemDetails => itemDetails;
    private ItemDetails itemDetails;
    public void AddItem(ItemDetails item)
    {
        itemDetails = item;
        itemName = item.ItemName;
        itemSprite = item.ItemSprite;
        AddQuantity(item.ItemQuantity);
    }
    public bool isEmpty => itemQty <= 0;
    public bool CanStackWith(string otherItemName)
    {
        return !isFull && itemName == otherItemName;
    }
    public void AddQuantity(int amount)
    {
        itemQty += amount;
        isFull = itemQty >= MaxStackSize;
        qtyText.text = itemQty.ToString();
        qtyText.enabled = true;
        itemImage.sprite = itemSprite;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            LeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            RightClick();
        }
    }
    private void LeftClick()
    {
        if (isEmpty || inventoryManager == null)
        {
            return;
        }
        inventoryManager.SelectSlot(this);
    }
    private void RightClick()
    {
        Debug.Log("Right Click");
    }
}
