using UnityEngine;

public class Coins : MonoBehaviour, IPickable
{
    public void PickUp()
    {
        CoinsText.Coin += 1;
        CoinsText.SendCoins();
        Destroy(gameObject);
    }
}
