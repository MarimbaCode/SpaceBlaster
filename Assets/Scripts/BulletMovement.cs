using System;
using System.Security.Cryptography;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Vector2 direction;
    public Rigidbody2D rb;
    public CircleCollider2D bulletCollider;
    public String side;

    public int damage;
    public int pierce;

    private const int Life = 100;
    private int _life;
    
    


    void Start()
    {
        _life = Life;
        rb.velocity = direction * 2;

    }

    void FixedUpdate()
    {
        if (_life-- <= 0 || pierce <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
