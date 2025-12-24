using System;
using System.Collections;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private float fireRate = 1f; // Скорострельность (выстрелов в секунду)
    [SerializeField] private Transform firePoint; // Точка вылета пули
    [SerializeField] private GameObject bulletPrefab; // Префаб пули
    [SerializeField] private Transform rotationPart; // Вращающаяся часть турели
    [SerializeField] private float offset;
    [SerializeField] private float detectionRadius = 5f; // Радиус обнаружения
    
    // Ссылки
    private Transform player;
    private bool playerInRange = false;
    private float fireTimer = 0f;

    private bool isShot = false;

    // Визуализация радиуса в редакторе
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
    
    private void Update()
    {
        if (playerInRange && player != null)
        {
            // Поворот турели в сторону игрока
            AimAtPlayer();
            if (!isShot) StartCoroutine(ShootLine());
        }
    }
    
    private void AimAtPlayer()
    {
        if (rotationPart == null) return;
        
        // Получаем направление к игроку
        Vector2 direction = player.position - rotationPart.position;
        
        // Вычисляем угол поворота
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        // Применяем поворот
        rotationPart.rotation = Quaternion.Euler(0f, 0f, angle + offset);
    }
    
    private void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;
        
        // Создаем пулю
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    IEnumerator ShootLine()
    {
        isShot = true;
        if (playerInRange)
        {
            yield return new WaitForSeconds(fireRate);
            for (int i = 0; i < 5; i++)
            {
                yield return new WaitForSeconds(0.4f);
                Shoot();
            }
        }

        isShot = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            playerInRange = true;
            fireTimer = 0f; // Сбрасываем таймер при первом обнаружении
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}