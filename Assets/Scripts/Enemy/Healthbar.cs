using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public Life life;
    public SpriteRenderer spriteRenderer;
    
    public String healthbarPath;
    public Sprite[] sprites;
    
    private int _maxHealth;
    

    private void Start()
    {
        _maxHealth = life.maxLife;

        sprites = Resources.LoadAll<Sprite>(healthbarPath);
    }

    // Update is called once per frame
    void Update()
    {
        int currentHealth = life.life;
        int healthbarState = Mathf.CeilToInt((currentHealth * 16f) / _maxHealth);

        spriteRenderer.sprite = sprites[16 - healthbarState];

    }
}
