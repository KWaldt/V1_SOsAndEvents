using System;
using KristinaWaldt;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public IntObject health;
    public IntObject maxHealth;

    public int Health
    {
        get => health.RuntimeValue;
        set
        {
            health.RuntimeValue = Mathf.Clamp(value, 0, maxHealth.RuntimeValue);
            if (Health <= 0)
            {
                // TODO: Die
            }
        }
    }

    private void Start()
    {
        Health = maxHealth.RuntimeValue;
    }

    public void TakeDamage(int debugAmount = 10)
    {
        Health -= debugAmount;
        Debug.Log(Health);
    }
}

[CustomEditor(typeof(Player))]
public class PlayerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var t = target as Player;

        if (GUILayout.Button("Damage"))
        {
            t.TakeDamage();
        }
        
        if (GUILayout.Button("Heal"))
        {
            // There should be a specific Heal() function so that you can play
            // different particles etc.
            t.TakeDamage(-10);
        }
    }
}
