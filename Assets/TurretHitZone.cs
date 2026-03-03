using System;
using UnityEngine;

public class TurretHitZone : MonoBehaviour
{
    [SerializeField] private GameObject turret;
    [SerializeField] private ParticleSystem turretHit;
    [SerializeField] private GameObject turretHitSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerAttack")
        {
            Destroy(turret);
            turretHitSprite.SetActive(false);
            turretHit.Play();
        }
    }
}
