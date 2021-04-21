using System;
using UnityEngine;

namespace KristinaWaldt
{
    [CreateAssetMenu(fileName = "IntObject", menuName = "Data/Variables/Maxed Int")]
    public class MaxedIntObject : VariableObject<int>
    {
        public IntObject currentIntObject;
        public IntObject maxIntObject;

        public void Subscribe(Action newAction)
        {
            currentIntObject.ValueChanged += newAction;
            maxIntObject.ValueChanged += newAction;
        }
        
        public void Unsubscribe(Action newAction)
        {
            currentIntObject.ValueChanged -= newAction;
            maxIntObject.ValueChanged -= newAction;
        }

        public float GetPercentage()
        {
            return (float)currentIntObject.RuntimeValue / maxIntObject.RuntimeValue;
        }
    }
}