using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour, GrabableItem
{
    InputAction inventoryAction;
    [SerializeField] GameObject InventoryCanvas;
    [SerializeField] private int slotCount = 16;
    [SerializeField] private ItemDetailsPanel detailsPanel;
    private bool inventoryActive;
    public ItemSlot[] itemSlot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateSlots();
        inventoryAction = InputSystem.actions.FindAction("Inventory");
        InventoryCanvas.SetActive(false);
        inventoryActive = false;

        if (detailsPanel == null)
        {
            Debug.LogWarning("No ItemDetailsPanel is assigned, item details will not be shown.", this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inventoryAction.triggered && inventoryActive == false)
        {
            inventoryActive = true;
            Time.timeScale = 0f;
            Debug.Log("inventory muncul");
            InventoryCanvas.SetActive(true);
            ShowFirstItem();
        }
        else if (inventoryAction.triggered && inventoryActive == true)
        {
            inventoryActive = false;
            Time.timeScale = 1f;
            Debug.Log("Inventory ditutup");
            InventoryCanvas.SetActive(false);
        }
    }
    private void CreateSlots()
    {
        ItemSlot itemSlotPrefab = Resources.Load<ItemSlot>("ItemSlot");
        if (itemSlotPrefab == null)
        {
            Debug.LogError("ItemSlot prefab tidak ditemukan dalam folder Resources", this);
            itemSlot = new ItemSlot[0];
            return;
        }
        Transform parent = InventoryCanvas.transform;
        GridLayoutGroup grid = InventoryCanvas.GetComponentInChildren<GridLayoutGroup>(true);
        if (grid != null)
        {
            parent = grid.transform;
        }
        itemSlot = new ItemSlot[slotCount];
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i] = Instantiate(itemSlotPrefab, parent);
            itemSlot[i].inventoryManager = this;
        }
    }
    public void AddItem(ItemDetails item)
    {
        Debug.Log("Item masuk inventory: " + item.ItemName + "Jumlah: " + item.ItemQuantity);
        if (itemSlot == null || itemSlot.Length == 0)
        {
            Debug.LogWarning("Inventory tidak memiliki slot, '" + item.ItemName + "'telah hilang");
            return;
        }
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].CanStackWith(item.ItemName))
            {
                itemSlot[i].AddQuantity(item.ItemQuantity);
                return;
            }
        }
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isEmpty)
            {
                itemSlot[i].AddItem(item);
                return;
            }
        }
        Debug.LogWarning("Inventory is full, '" + item.ItemName + "' was lost.");
    }
    public void SelectSlot(ItemSlot slot)
    {
        DesselectAllSlot();
        slot.SelectedPanel.SetActive(true);
        slot.isItemSelected = true;

        if (detailsPanel != null)
        {
            detailsPanel.Show(slot.ItemDetails, slot.itemQty);
        }
    }
    private void ShowFirstItem()
    {
        if (itemSlot != null)
        {
            foreach (ItemSlot slot in itemSlot)
            {
                if (!slot.isEmpty)
                {
                    SelectSlot(slot);
                    return;
                }
            }
        }
        if (detailsPanel != null)
        {
            detailsPanel.Clear();
        }
    }
    public void DesselectAllSlot()
    {
        foreach (ItemSlot slot in itemSlot)
        {
            slot.isItemSelected = false;
            slot.SelectedPanel.SetActive(false);
        }
    }
}
