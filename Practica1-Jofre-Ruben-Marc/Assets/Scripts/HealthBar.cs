using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    float initialScale;
    public void SetMaxHealt(float health)
    {
        Debug.Log("Setemaos max health");
        initialScale = transform.localScale.x;
        transform.localScale = new Vector3(initialScale,transform.localScale.y,transform.localScale.z);
    }

    public void SetHealth(int health, int maxHealth)
    {
        transform.localScale = new Vector3(health * initialScale /maxHealth, transform.localScale.y, transform.localScale.z);
    }
}
