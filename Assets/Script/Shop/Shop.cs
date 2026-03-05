using System;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject ShopPanel;
    [SerializeField] private PlayerMeleWeapon playerAtac;
    [SerializeField] private HealthUI playerHealthUI;
    [SerializeField] private GameObject InputPanel;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShopPanel.SetActive(false);
            InputPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InputPanel.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                InputPanel.SetActive(false);
                ShopPanel.SetActive(true);
            }
        }
    }

    public void BuyHP(int cost)
    {
        if (CoinsText.Coin >= cost)
        {
            CoinsText.Coin -= cost;
            playerHealthUI.ChangeHeartsCount(1);
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
