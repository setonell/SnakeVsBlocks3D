using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Food : MonoBehaviour
{ 
    public int CountFood;
    public TextMeshPro Text;

    private void Awake()
    {
        CountFood = Random.Range(1, 15);
        Text.text = CountFood.ToString();
    }
}
