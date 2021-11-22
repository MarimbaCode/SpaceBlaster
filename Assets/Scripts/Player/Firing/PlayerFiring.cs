using System;
using UnityEngine;

namespace Player.Firing
{
    public abstract class PlayerFiring : MonoBehaviour
    {
        private Camera _mainCamera;
        protected Vector2 AimDirection;

        protected int CooldownTime = 10;
        protected int FireRate = 10;
        private int _cooldown;

        protected float Strength;

        protected readonly String PrefabPath = "Prefabs/player/projectiles/";
        
        protected void Init()
        {
            _mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        }

        void FixedUpdate()
        {
            FireRate = (int)(CooldownTime / Strength);
            Aim();
            if (_cooldown-- <= 0)
            {
                _cooldown = FireRate;
                Fire();
            }

            Strength = GetComponent<PlayerStrengthScale>().additive;
        }
        void Aim()
        {
            Vector3 mouse = Input.mousePosition;
            Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(mouse);

            AimDirection = ((Vector2) (mousePosition - transform.position)).normalized;
        }


        public abstract void Fire();
    }
}
