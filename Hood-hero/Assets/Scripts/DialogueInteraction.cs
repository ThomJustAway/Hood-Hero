using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class DialogueInteraction : MonoBehaviour
    {
        [SerializeField] private GameObject button;
        [SerializeField] private float distanceToSense = 1f;

        // Update is called once per frame
        void Update()
        {
            NPCInteract();
        }

        private void NPCInteract()
        {
            // Add extra perimeter here to only do RayCasting NPCs
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distanceToSense);
            Debug.DrawRay(transform.position, transform.up * distanceToSense, Color.green);

            if (hit.collider == null)
            {
                button.SetActive(false);
            }
            else
            {
                button.SetActive(true);
            }
        }
    }
}