using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;
using System;

internal enum Legs
{
    Spark,
    Spark_top,
}

public class LegHandler : MonoBehaviour
{
    [SerializeField] private GameObject _leg;

    [SerializeField]
    private SerializableDictionaryBase<Legs, GameObject> _legDictionary;

    //TODO 取得當前腳的底部座標
    public float GroundPosition;

    // Start is called before the first frame update
    private void Start()
    {
        var arm = Instantiate(_legDictionary[Legs.Spark], transform.localPosition, Quaternion.identity);
        arm.transform.SetParent(transform, false);
    }

    public void SwitchArm()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        Array values = Enum.GetValues(typeof(Legs));
        System.Random random = new System.Random();
        Legs randomBar = (Legs)values.GetValue(random.Next(values.Length));

        var arm = Instantiate(_legDictionary[randomBar], transform.localPosition, Quaternion.identity);
        arm.transform.SetParent(transform, false);
    }
}