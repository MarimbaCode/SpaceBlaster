using System;
using System.Collections;
using System.Collections.Generic;
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

    public LevelManager manager;

    private void Start()
    {
        life = maxLife;
        manager = GameObject.FindWithTag("GameController").GetComponent<LevelManager>();
    }

    public void Damage(int damage)
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
        
        
    }
}
