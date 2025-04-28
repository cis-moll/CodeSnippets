using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    private Transform target;
    private int pathIndex = 0;
    private float baseSpeed;
    public int pathNumber;

    private void Start()
    {
        baseSpeed = moveSpeed;
        if (pathNumber == 1)
        {
            target = LevelManager.main.path1[0];
        }
        else if (pathNumber == 2)
        {
            target = LevelManager.main.path2[0];
        }
        else if (pathNumber == 3)
        {
            target = LevelManager.main.path3[0];
        }
    }

    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;

            if (pathNumber == 1)
            {
                if (pathIndex >= LevelManager.main.path1.Length)
                {
                    EnemySpawner.onEnemyDestroy.Invoke();
                    Destroy(gameObject);
                    return;
                }
                else
                {
                    target = LevelManager.main.path1[pathIndex];
                }
            }
            else if (pathNumber == 2)
            {
                if (pathIndex >= LevelManager.main.path2.Length)
                {
                    EnemySpawner.onEnemyDestroy.Invoke();
                    Destroy(gameObject);
                    return;
                }
                else
                {
                    target = LevelManager.main.path2[pathIndex];
                }
            }
            else if (pathNumber == 3)
            {
                if (pathIndex >= LevelManager.main.path3.Length)
                {
                    EnemySpawner.onEnemyDestroy.Invoke();
                    Destroy(gameObject);
                    return;
                }
                else
                {
                    target = LevelManager.main.path3[pathIndex];
                }
            }
        }
    }
    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;
    }

    public void UpdateSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    public void ResetSpeed()
    {
        moveSpeed = baseSpeed;
    }
}
