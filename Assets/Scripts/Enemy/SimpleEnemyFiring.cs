﻿using UnityEngine;

namespace Enemy
{
    public class SimpleEnemyFiring : MonoBehaviour
    {
    
        public GameObject bulletPrefab;

        public GameObject player;
    
        private const int CooldownTime = 32;
        private int _cooldown = CooldownTime;

        private Vector2 _aim;




        void FixedUpdate()
        {
            player = GameObject.FindWithTag("Player");
            Aim();
            if (_cooldown-- <= 0)
            {
                _cooldown = CooldownTime;
                if (_aim.magnitude < 8)
                {
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
            BulletMovement projectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity)
                .GetComponent<BulletMovement>();
            projectile.direction = _aim.normalized * 4;
            projectile.side = "ENEMY";
            projectile.damage = 1;
        }
    }
}
