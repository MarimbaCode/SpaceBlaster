using System;
using UnityEngine;

namespace Player.MovementAbilities
{
    public abstract class Movement : MonoBehaviour
    {
        public Energy energy;
        public Rigidbody2D rb;
        public Life life;
        
        public int energyCost;
        public int cooldownTime;
        public int cooldown;
       
        public Camera mainCamera;

        public void Awake()
        {
            energy = GetComponentInParent<Energy>();
            rb = GetComponentInParent<Rigidbody2D>();
            life = GetComponentInParent<Life>();
            
            mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        }

        private void FixedUpdate()
        {
            cooldown--;
        }

        public void Update()
        {
            if(cooldown > 0){return;}
            if (Input.GetKeyDown(KeyCode.LeftShift) && energy.energy >= energyCost)
            {
                energy.energy -= energyCost; 
                Move();
                cooldown = cooldownTime;
            }
        }

        public abstract void Move();
    }
}
