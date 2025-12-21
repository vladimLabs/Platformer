using UnityEngine;

public class BankAmmo : MonoBehaviour, IPickable
{
    public void PickIp()
    {
        FindAnyObjectByType<PlayerRevolver>().AddAmmo(6);
        Destroy(gameObject);
            //GameAnalyticsManager.AmmoPicked();
    }
}
