using UnityEngine;

[CreateAssetMenu(fileName = "ItemDetails", menuName = "Scriptable Objects/ItemDetails")]
public class ItemDetails : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private int quantity = 1;
    [SerializeField] private Sprite itemSprite;
    [SerializeField, TextArea] private string description; 

    public string ItemName => itemName;
    public int ItemQuantity => quantity;
    public Sprite ItemSprite => itemSprite;
    public string Description => description;
}
