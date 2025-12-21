using System;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject ShopPanel;
    [SerializeField] private PlayerAtac playerAtac;
    [SerializeField] private HealthUI pleayrHealth;
    

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShopPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShopPanel.SetActive(true);
            GameAnalyticsManager.Shop();
        }
    }

    public void BuyHP(int cost)
    {
        if (CoinsText.Coin >= cost)
        {
            CoinsText.Coin -= cost;
            pleayrHealth.AddHp();
        }
    }

    public void BuyDamage(int cost)
    {
        if (CoinsText.Coin >= cost)
        {
            CoinsText.Coin -= cost;
            playerAtac.AddDamage(0.25f);
        }
    }
    
}
