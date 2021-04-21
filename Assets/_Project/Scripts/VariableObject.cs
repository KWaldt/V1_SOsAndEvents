using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class VariableObjectBase : ScriptableObject
{
    public event Action ValueChanged;

    protected void CallValueChanged()
    {
        ValueChanged?.Invoke();
    }
}

public abstract class VariableObject<T> : VariableObjectBase, ISerializationCallbackReceiver
{
    public event Action<T> ValueChangedTo;
    
    [SerializeField] private T defaultValue;
    
    private T runtimeValue;
    public T RuntimeValue
    {
        get => runtimeValue;
        set
        {
            if (EqualityComparer<T>.Default.Equals(value, runtimeValue))
                return;

            runtimeValue = value;
            CallValueChanged();
            ValueChangedTo?.Invoke(runtimeValue);
        }
    }
	
    public void OnBeforeSerialize()
    {
    }

    public void OnAfterDeserialize()
    {
        ResetValue();
    }

	public void ResetValue()
	{
	    RuntimeValue = defaultValue;
	}
}