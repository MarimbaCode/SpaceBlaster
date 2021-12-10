using UnityEngine;

namespace Enemy.Firing
{
    public class TripleEnemyFiring : MonoBehaviour
    {

        public GameObject bulletPrefab;

        public GameObject player;

        public Aggro aggro;
        
        public int cooldownTime = 32;
        public int bursts = 1;
        public int burstCooldownTime = 6;
        public int burstCooldown = 0;
        private int _cooldown = 0;

        private Vector2 _aim;

        private int inBurst;



        void FixedUpdate()
        {
            player = GameObject.FindWithTag("Player");
            Aim();
            if (aggro.persuit)
            {
                if (inBurst > 0 && burstCooldown-- <= 0)
                {
                    inBurst--;
                    Fire();
                    burstCooldown = burstCooldownTime;

                }
                else if (_cooldown-- <= 0)
                {
                    _cooldown = cooldownTime;
                    inBurst = bursts;
                }
            }
            else
            {
                _cooldown--;
                burstCooldown--;
            }
        }

        void Aim()
        {
            _aim = player.transform.position - transform.position;
        }


        void Fire()
        {
            
            BulletMovement projectile1 = Instantiate(bulletPrefab, transform.position + (Vector3)(_aim.normalized * 0.5f), Quaternion.identity)
                .GetComponent<BulletMovement>();
            projectile1.direction = Utils.Rotate(_aim.normalized, Mathf.PI / 12) * 4;
            projectile1.side = "ENEMY";
            projectile1.damage = 1;
            
            BulletMovement projectile2 = Instantiate(bulletPrefab, transform.position + (Vector3)(_aim.normalized * 0.5f), Quaternion.identity)
                .GetComponent<BulletMovement>();
            projectile2.direction = _aim.normalized * 4;
            projectile2.side = "ENEMY";
            projectile2.damage = 1;
            
            BulletMovement projectile3 = Instantiate(bulletPrefab, transform.position + (Vector3)(_aim.normalized * 0.5f), Quaternion.identity)
                .GetComponent<BulletMovement>();
            projectile3.direction = Utils.Rotate(_aim.normalized, Mathf.PI / -12) * 4;
            projectile3.side = "ENEMY";
            projectile3.damage = 1;
        }
    }
}
