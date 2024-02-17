using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    //Unity Inspector

    [SerializeField] private int health_;
    [SerializeField] private UnityEvent healthChange_;

    public int Value
    {
        get { return health_; }
    }

    public void Decrease(int amount)
    {
        if (health_.Equals(0))
        {
            //already dead
            return;
        }
        health_ -= amount;
        healthChange_.Invoke();
    }
}