using System;
using System.Collections;
using System.Collections.Generic;
using LevelManagers.Managers;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
    public LevelManager levelManager;
    public Transform spawnPosition;
    void Start()
    {
        levelManager = GameObject.FindWithTag("GameController").GetComponent<LevelManager>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        levelManager.SetRespawnPoint(spawnPosition.position);
    }
}
