using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    [SerializeField] private bool flipUsingRotation = true;

    private Quaternion rightRotation = Quaternion.Euler(0, 0, 0);
    private Quaternion leftRotation = Quaternion.Euler(0, 180, 0);

    public void UpdateFlip(float horizontalVelocity)
    {
        if (horizontalVelocity > 0.1f)
        {
            ApplyFlip(false);
        }
        else if (horizontalVelocity < -0.1f)
        {
            ApplyFlip(true);
        }
    }

    private void ApplyFlip(bool facingLeft)
    {
        if (flipUsingRotation)
        {
            transform.rotation = facingLeft ? leftRotation : rightRotation;
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.x = facingLeft ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }
}