using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoodHeroUI
{
    public class Movement : MonoBehaviour
    {
        //legacy code, and replace this

        [SerializeField]
        public float mWalkSpeed = 10f;



        void Update()
        {
            Move();
        }

        private void Move()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector2 move = new Vector2 (h, v);
            transform.Translate(move * Time.deltaTime * mWalkSpeed);
        }
    
    
    }
}
       

    
