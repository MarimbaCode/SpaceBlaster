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
    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        BulletMovement proj = otherObject.GetComponent<BulletMovement>();
        if(proj == null){return;}
        if (!proj.side.Equals(side))
        {
            _life -= proj.damage;
            proj.pierce--;

            if (_life <= 0)
            {
                manager.GameDeath(id);
                Destroy(gameObject);
            }
        }
    }
}
