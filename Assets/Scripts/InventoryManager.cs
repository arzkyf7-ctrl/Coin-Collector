using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour, GrabableItem
{
    InputAction inventoryAction;
    [SerializeField] GameObject InventoryCanvas;
    [SerializeField] private int slotCount = 16;
    private bool inventoryActive;
    public ItemSlot[] itemSlot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateSlots();
        inventoryAction = InputSystem.actions.FindAction("Inventory");
        InventoryCanvas.SetActive(false);
        inventoryActive=false;

    }

    // Update is called once per frame
    void Update()
    {
        if (inventoryAction.triggered && inventoryActive==false)
        {
            InventoryCanvas.SetActive(true);
            inventoryActive = true;
            Time.timeScale = 0f;
            Debug.Log("inventory muncul");
            InventoryCanvas.SetActive(true);
        } else if (inventoryAction.triggered&&inventoryActive==true)
        {
            InventoryCanvas.SetActive(false);
            inventoryActive = false;
            Time.timeScale = 1f;
            Debug.Log("Inventory ditutup");
            InventoryCanvas.SetActive(false);
        }
    }
    private void CreateSlots()
    {
        ItemSlot slotPrefab = Resources.Load<ItemSlot>("Item");
        if (slotPrefab == null)
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
            itemSlot[i] = Instantiate(slotPrefab, parent);
        }
    }
    public void AddItem(ItemDetails item)
    {
        Debug.Log("Item masuk inventory: " + item.ItemName + "Jumlah: " + item.ItemQuantity);
        if (itemSlot==null||itemSlot.Length==0)
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
            if (!itemSlot[i].isFull)
            {
                itemSlot[i].AddItem(item);
                return;
            }
        }
        Debug.LogWarning("Inventory is full, '" + item.ItemName + "' was lost.");
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
