using System;
using UnityEngine;

namespace Player.Firing
{
    public class PlayerFireNebulaBolt : PlayerFiring
    {
        public int speed;

        public GameObject bulletPrefab;
        private void Start()
        {
            Init();

            FireSpeed = 1.8f;

            bulletPrefab = Resources.Load(PrefabPath + "NebulaBolt") as GameObject;
        }

        public override void Fire()
        {
            GameObject projectile = Instantiate(bulletPrefab, transform.position + (Vector3)(AimDirection.normalized * 0.2f), Quaternion.identity);
            NebulaBoltMovement movement = projectile.GetComponent<NebulaBoltMovement>();
            movement.side = "player";
            movement.pierce = 2;
            movement.damage = 1;
            movement.direction = AimDirection.normalized * 4;
        }
    }
}
