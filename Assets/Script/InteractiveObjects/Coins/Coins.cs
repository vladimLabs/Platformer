using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class Coins : MonoBehaviour, IPickable
{
    private CoinsManeger coinsManeger;

    [Inject]
    private void Construct(CoinsManeger _coinsManeger)
    {
        coinsManeger =  _coinsManeger;
    }

    public void PickUp()
    {
        coinsManeger.AddCoin(1);
        Destroy(gameObject);
    }
}
