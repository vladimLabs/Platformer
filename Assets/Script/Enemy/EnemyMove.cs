using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speedEnemy;
    [SerializeField] private Rigidbody2D rb;
    private GameObject pLayer;

    void Start()
    {
        pLayer = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        MoveEn();
    }

    private void MoveEn()
    {
        if (pLayer != null)
        {
            Vector2 movement = new Vector2(speedEnemy, rb.linearVelocityY);
            rb.linearVelocity = movement;
        }
    }
}
