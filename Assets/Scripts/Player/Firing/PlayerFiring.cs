using System;
using UnityEngine;

namespace Player.Firing
{
    public abstract class PlayerFiring : MonoBehaviour
    {
        protected Camera MainCamera;
        protected Vector2 AimDirection;

        protected int Cooldown = 10;
        protected float FireSpeed = 1;
        protected int FireRate = 10;
        private int _cooldown;

        protected float Strength = 1;

        protected readonly String PrefabPath = "Prefabs/player/projectiles/";
        
        protected void Init()
        {
            MainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        }
        

        void FixedUpdate()
        {
            FireRate = (int)(Cooldown * FireSpeed * Strength);
            Aim();
            if ((_cooldown-- <= 0 && Input.GetMouseButton(0)))
            {
                _cooldown = FireRate;
                Fire();
            }

        }
        void Aim()
        {
            Vector3 mouse = Input.mousePosition;
            Vector3 mousePosition = MainCamera.ScreenToWorldPoint(mouse);

            AimDirection = ((Vector2) (mousePosition - transform.position)).normalized;
        }


        public abstract void Fire();
    }
}
