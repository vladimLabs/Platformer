using UnityEngine;

public class WeaponChooser : MonoBehaviour
{
    [SerializeField] private WeaponGeneral[] weapons;
    [SerializeField] private GameObject[] icons;

    public int currentWeaponIndex;

    private void SwitchWeapon(int indexChange)
    {
        weapons[currentWeaponIndex].enabled = false;

        icons[currentWeaponIndex].transform.localScale = new Vector3(0.7f , 0.7f , 0.7f);

        if (currentWeaponIndex + indexChange >= weapons.Length)
        {
            currentWeaponIndex = 0;
        }
        else if (currentWeaponIndex + indexChange < 0)
        {
            currentWeaponIndex = weapons.Length - 1;
        }
        else 
        { 
            currentWeaponIndex += indexChange; 
        }

        icons[currentWeaponIndex].transform.localScale = new Vector3(1, 1, 1);

        weapons[currentWeaponIndex].enabled = true;
    }
    private void Update()
    {
        if(Input.mouseScrollDelta.y > 0)
        {
            SwitchWeapon(1);
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            SwitchWeapon(-1);
        }
    }
}
