using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Playground Item", order = 51)]
public class ItemData : ScriptableObject
{
    [Header ("Model Prefab")]
    [Tooltip ("Prefab to be Instantiate on the Scene")]
    public GameObject Model;

    [Header("Properties")]
    [Tooltip("Item Name")]
    public string Name;
    [Tooltip("Item Description")]
    public string Description;
    [Tooltip("Time to Live")]
    [Range(1.0f, 5.0f)]
    public float TTL;
    [Tooltip("Score when collected")]
    public int Score;
}
