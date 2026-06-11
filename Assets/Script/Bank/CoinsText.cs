using TMPro;
using UnityEngine;
using Zenject;

public class CoinsText : MonoBehaviour
{
    public int Coin;
    TextMeshProUGUI text;
    private CoinsManeger coinsManeger;

    [Inject]
    private void Construct(CoinsManeger _coinsManeger)
    {
        coinsManeger = _coinsManeger;
    }

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        text.text = coinsManeger.GetCoin().ToString();
    }
}
