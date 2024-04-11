using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    // Тригер через компонент
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameShopSystemManager.instance.ToggleShop();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameShopSystemManager.instance.ToggleShop();
            GameShopSystemManager.instance.OffAllShops();
        }
    }
}
