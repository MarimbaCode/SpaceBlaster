using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class Boss1Firing : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Aggro aggro;

    private GameObject player;

    private int state;
    private int stateTemp;
    private int cooldown;
    private Vector2 vectorTemp;
    private void FixedUpdate()
    {
        player = GameObject.FindWithTag("Player");
        if (cooldown-- <= 0 && aggro.persuit)
        {

            switch (state)
            {
                
                case 0:
            
                    for (float theta = 0; theta < 2 * Mathf.PI; theta += (Mathf.PI /32))
                    {
                        shoot(Utils.Rotate(Vector2.right, theta), 2);
                    }
            
                    cooldown = 48;
                    state++;
                    break;
                case 1:
            
                    if (stateTemp++ < 16)
                    {
                        shoot(4);
                        cooldown = 6;
                    }
                    else
                    {
                        state++;
                        stateTemp = 0;
                    }
                    break;
                case 2:
                    if (stateTemp <= 5)
                    {
                        vectorTemp = ((Vector2) (player.transform.position - transform.position)).normalized;
                    }
            
                    if (stateTemp++ < 60)
                    {
                        shoot(Utils.Rotate(vectorTemp, Mathf.PI/4), 12);
                        shoot(Utils.Rotate(vectorTemp, -Mathf.PI/4), 12);
                        
                        cooldown = 1;
                    }
                    else
                    {
                        state++;
                        stateTemp = 0;
                    }
                    break;
                
                
                
                default:
                    state = 0;
                    break;
            
            }
            
            
            
            
            
            
            
            
            
            
        }
        
        
        
    }

    void shoot(Vector2 direction, int speed)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        BulletMovement movement = bullet.GetComponent<BulletMovement>();
        movement.direction = direction * speed;
        movement.life = 1000;
    }
    
    void shoot(int speed)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        BulletMovement movement = bullet.GetComponent<BulletMovement>();
        movement.direction = ((Vector2)(player.transform.position - transform.position)).normalized * speed;
        movement.life = 1000;
    }
    void shoot(int speed, float angle)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        BulletMovement movement = bullet.GetComponent<BulletMovement>();
        movement.direction = Utils.Rotate((Vector2)(player.transform.position - transform.position), angle).normalized * speed;
        movement.life = 1000;
    }
}
