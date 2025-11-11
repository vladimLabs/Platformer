using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinsText : MonoBehaviour
{
    public static int Coin;
    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        text.text = Coin.ToString();
    }
}
