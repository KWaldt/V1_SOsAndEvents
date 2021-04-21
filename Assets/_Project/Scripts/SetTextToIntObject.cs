using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace KristinaWaldt
{
    public class SetTextToIntObject : MonoBehaviour
    {
        // Kann auch public sein
        [SerializeField] private IntObject intObject;
        
        private TextMeshProUGUI textmesh;
        
        public UnityEvent testEvent;


        private void Awake()
        {
            textmesh = GetComponent<TextMeshProUGUI>();
            OnValueChangedTo(intObject.RuntimeValue);
        }

        private void OnEnable()
        {
            // Add Listener
            intObject.ValueChangedTo += OnValueChangedTo;
        }
        
        private void OnDisable()
        {
            // Remove Listener
            intObject.ValueChangedTo -= OnValueChangedTo;
        }

        private void OnValueChangedTo(int value)
        {
            // 1 = 001
            textmesh.text = value.ToString("D3");
        }
    }
}