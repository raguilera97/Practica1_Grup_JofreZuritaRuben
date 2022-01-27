using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] PlayerController pla;
    [SerializeField] HealthBar hb;
    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    public int level = 0;
    public int experience = 0;
    public int nextLevel = 100;

    public void AddExperience(int expGained)
    {
        experience += expGained;
        if(experience >= nextLevel)
        {
            level++;
            experience = 0;
            if(OnLevelChanged != null)
            {
                OnLevelChanged(this, EventArgs.Empty);
                nextLevel = nextLevel * 2;
                pla.maxHealth = pla.maxHealth + 20;
                pla.currentHealth = pla.maxHealth;
                pla.damage = pla.damage + 2;
                pla.atackVelocity = pla.atackVelocity + 2;
                pla.armor = pla.armor + 1;
                hb.SetMaxHealt(pla.maxHealth);
                hb.SetHealth(pla.maxHealth, pla.maxHealth);
            }
        }
        if(OnExperienceChanged != null)
        {
            OnExperienceChanged(this, EventArgs.Empty);
        }
    }

    public int GetLevelNumber()
    {
        return level;
    }

    public float GetExpNormalized()
    {
        return (float)experience / nextLevel;
    }

}
