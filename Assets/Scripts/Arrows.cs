using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ebleme.KBB3DRunner
{
    public class Arrows : MonoBehaviour
    {
        [Header("Colors")]
        [SerializeField]
        private Color selectedColor = Color.green;

        [SerializeField]
        private Color unselectedColor = Color.white;
        
        [Header("References")]
        [SerializeField] private Image top;
        [SerializeField] private Image left;
        [SerializeField] private Image right;
        [SerializeField] private Image bottom;


        private Vector3 movementInput;
        
        private void Update()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveZ = Input.GetAxisRaw("Vertical");

            movementInput = new Vector3(moveX, 0, moveZ).normalized;
            
            left.color = movementInput.x < 0 ? selectedColor : unselectedColor;
            right.color = movementInput.x > 0 ? selectedColor : unselectedColor;
            top.color = movementInput.z > 0 ? selectedColor : unselectedColor;
            bottom.color = movementInput.z < 0 ? selectedColor : unselectedColor;
            
        }
    }
}