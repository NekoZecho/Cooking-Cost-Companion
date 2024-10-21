using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataTest : MonoBehaviour
{
    public float flourAmt;
    public float flourCost;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("Flour", flourAmt);
    }
}
