using UnityEngine;

namespace Player.Firing
{
    public class PlayerFireSolarBolt : PlayerFiring
    {
        public int speed;

        public GameObject bulletPrefab;
        private void Start()
        {
            Init();

            FireSpeed = 0.6f;

            bulletPrefab = Resources.Load(PrefabPath + "SolarBolt") as GameObject;
        }

        public override void Fire()
        {
            GameObject projectile = Instantiate(bulletPrefab, transform.position + (Vector3)(AimDirection.normalized * 0.2f), Quaternion.identity);
            SolarBoltMovement movement = projectile.GetComponent<SolarBoltMovement>();
            movement.side = "player";
            movement.pierce = 1;
            movement.damage = 1;
            movement.direction = AimDirection.normalized * 6;
        }
    }
}
