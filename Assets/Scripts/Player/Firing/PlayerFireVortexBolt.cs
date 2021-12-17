using UnityEngine;
using System;
using Random = System.Random;

namespace Player.Firing
{
    public class PlayerFireVortexBolt : PlayerFiring
    {
        
        public int speed;

        private float _sqrt2 = Mathf.Sqrt(2);
        public Random Rnd;
        
        public GameObject bulletPrefab;
        private void Start()
        {
            Init();

            FireSpeed = 3f;

            bulletPrefab = Resources.Load(PrefabPath + "VortexBolt") as GameObject;

            Rnd = new Random();
        }

        public override void Fire()
        {
            GameObject projectile = Instantiate(bulletPrefab,
                transform.position + (Vector3) AimDirection.normalized * 0.2f, Quaternion.identity);
            VortexBoltMovement movement = projectile.GetComponent<VortexBoltMovement>();
            movement.side = "player";
            movement.pierce = 1;
            movement.damage = 5;
            movement.direction = AimDirection.normalized * 4;

        }
    }
}
