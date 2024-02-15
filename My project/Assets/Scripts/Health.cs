using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //Unity Inspector

    [SerializeField] private int health_;

    public int Value
    {
        get { return health_; }
    }

    public void Damage(int amount)
    {
        if (health_.Equals(0))
        {
            //already dead
            return;
        }
        health_ -= amount;
    }
}