using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Death : MonoBehaviour
{
    //Unity Inspector

    [SerializeField] private UnityEvent died_;

    public void CheckDeath(int health)
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
        died_.Invoke();
    }
}