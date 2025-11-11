using UnityEngine;

public class InteractiveObjectsCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactive")
        {
            collision.GetComponent<IPickable>().PickUp();
        }
    }
}