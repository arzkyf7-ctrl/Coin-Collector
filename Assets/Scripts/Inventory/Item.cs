using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemDetails itemDetails;
    private GrabableItem itemCollector;

    private void Awake()
    {
        foreach (MonoBehaviour component in FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None))
        {
            if (component is GrabableItem collector)
            {
                itemCollector = collector;
                break;
            }
        }
        if (itemCollector == null)
        {
            Debug.LogError("Tidak ditemukan komponen aktif yang mengimplementasikan GrabableItem di dalam scene.", this);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && itemDetails != null && itemCollector != null)
        {
            itemCollector.AddItem(itemDetails);
            Destroy(gameObject);
        }
    }
}
