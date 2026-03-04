using System;
using UnityEngine;

public class BossAim : MonoBehaviour
{
    [SerializeField] private Transform rotationPart;
    
    [SerializeField] private Transform player;
    [SerializeField] private float offset;
    
    public bool aiming = true;
    private void Update()
    {
        if(!aiming) return;
        AimAtPlayer();
    }

    private void AimAtPlayer()
    {
        if (rotationPart == null) return;
        
        Vector2 direction = player.position - rotationPart.position;
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        rotationPart.rotation = Quaternion.Euler(0f, 0f, angle + offset);
    }
}
