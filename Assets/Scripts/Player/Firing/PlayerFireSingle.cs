using UnityEngine;

namespace Player.Firing
{
    public class PlayerFireSingle : PlayerFiring
    {
        public int speed;

        public GameObject bulletPrefab;
        private void Start()
        {
            Init();

            CooldownTime = 20;

            bulletPrefab = Resources.Load(PrefabPath + "PlayerBullet") as GameObject;
        }

        public override void Fire()
        {
            GameObject projectile = Instantiate(bulletPrefab, transform.position + (Vector3)(AimDirection.normalized * 0.1f), Quaternion.identity);
            BulletMovement movement = projectile.GetComponent<BulletMovement>();
            movement.side = "player";
            movement.pierce = 2;
            movement.damage = 1;
            movement.direction = AimDirection.normalized * 8;
        }
    }
}
