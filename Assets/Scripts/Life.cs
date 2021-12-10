using System;
using System.Collections;
using System.Collections.Generic;
using LevelManagers;
using LevelManagers.Managers;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int maxLife;
    private int _life;

    public String side;
    public String id;

    public LevelManager manager;

    private void Start()
    {
        _life = maxLife;
        manager = GameObject.FindWithTag("GameController").GetComponent<LevelManager>();
    }

    public void Damage(int damage)
    {
        _life -= damage;
        if (_life <= 0)
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
