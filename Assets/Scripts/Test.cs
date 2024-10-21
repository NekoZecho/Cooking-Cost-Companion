using UnityEngine;
using TMPro;
public class GetInputFieldValue : MonoBehaviour
{
    [SerializeField]
    TMP_InputField flour;
    [SerializeField]
    TMP_InputField flourCost;
    float flourAmt;
    float cost;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cost = PlayerPrefs.GetFloat("Flour Cost");
        Debug.Log(cost);
        flourAmt = PlayerPrefs.GetFloat("Flour Amount");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float.TryParse(flourCost.text, out cost);
            Debug.Log(cost);
            PlayerPrefs.SetFloat("Flour Cost", cost);
            float.TryParse(flour.text, out flourAmt);
            Debug.Log(flourAmt);
            PlayerPrefs.SetFloat("Flour Amount", flourAmt);
            Debug.Log(flourAmt * cost);
        }
    }
}
