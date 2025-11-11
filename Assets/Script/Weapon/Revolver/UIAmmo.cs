using TMPro;
using UnityEngine;

public class UIAmmo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    public void UpdateUI(int ammo, int bankAmmo)
    {
        text.text = ammo.ToString() + "/" + bankAmmo.ToString();
    }
}
