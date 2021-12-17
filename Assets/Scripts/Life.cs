using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using LevelManagers;
using LevelManagers.Managers;
using UnityEngine;
using UnityEngine.Serialization;

public class Life : MonoBehaviour
{
    public int maxLife;
    public int life;

    public String side;
    public String id;

    public int invulnerable;

    public LevelManager manager;

    private void Start()
    {
        life = maxLife;
        manager = GameObject.FindWithTag("GameController").GetComponent<LevelManager>();
    }

    private void FixedUpdate()
    {
        if (invulnerable > 0)
        {
            invulnerable--;
        }
    }

    public void Damage(int damage)
    {
        if (invulnerable <= 0)
        {
            life -= damage;
            if (life <= 0)
            {

                if (id.Equals("Player"))
                {
                    manager.RespawnPlayer();
                    Destroy(gameObject);
                }
                else
                {
                    manager.GameDeath(id);
                    Destroy(gameObject);
                }
            }

            Aggro ag = GetComponent<Aggro>();
            if (ag != null)
            {
                ag.aggroTimer = ag.aggroTime * 4;
            }

        }

    }

    public void AddInvincibility(int n)
    {
        invulnerable += n;
    }
}
