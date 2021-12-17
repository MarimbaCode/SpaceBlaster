﻿using UnityEngine;

namespace Enemy
{
    public class SimpleEnemyFiring : MonoBehaviour
    {
    
        public GameObject bulletPrefab;

        public GameObject player;

        public Aggro aggro;
    
        public int cooldownTime = 32;
        private int _cooldown = 0;

        public int bulletSpeed = 3;

        private Vector2 _aim;




        void FixedUpdate()
        {
            player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                Aim();
                if (_cooldown-- <= 0 && aggro.persuit)
                {
                    _cooldown = cooldownTime;
            
                        Fire();
                    
                }
            }
        }

        void Aim()
        {
            _aim = player.transform.position - transform.position;
        }


        void Fire()
        {
            BulletMovement projectile = Instantiate(bulletPrefab, transform.position + (Vector3)(_aim.normalized * 0.5f), Quaternion.identity)
                .GetComponent<BulletMovement>();
            projectile.direction = _aim.normalized * bulletSpeed;
            projectile.side = "ENEMY";
            projectile.damage = 1;
            projectile.life = 300;
        }
    }
}
