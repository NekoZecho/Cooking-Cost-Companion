using UnityEngine;
using TMPro;
using System;
public class GetInputFieldValue : MonoBehaviour
{
    [SerializeField]
    TMP_InputField flour;
    [SerializeField]
    TMP_InputField flourCost;
    [SerializeField]
    TMP_InputField markupField;
    [SerializeField]
    TMP_InputField batchQuantity;
    [SerializeField]
    TMP_Text PPU;
    float flourAmt;
    float cost;
    float markup;
    float quantityOfBatch;
    float pricePerUnit;
    GameObject[] Names;
    GameObject[] Costs;
    GameObject[] Qty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Names = GameObject.FindGameObjectsWithTag("Name");
            Costs = GameObject.FindGameObjectsWithTag("Cost");
            Qty = GameObject.FindGameObjectsWithTag("Qty");
            float sum = 0;
            for (int i = 0; i < Costs.Length; i++)
            {
                float c = 0;
                float.TryParse(Costs[i].GetComponent<TMP_InputField>().text, out c);
                float q = 0;
                float.TryParse(Qty[i].GetComponent<TMP_InputField>().text, out q);
                sum += (c * q);
            }
            float.TryParse(markupField.text, out markup);
            PlayerPrefs.SetFloat("Markup", markup);
            float.TryParse(batchQuantity.text, out quantityOfBatch);
            PlayerPrefs.SetFloat("Units Per Batch", quantityOfBatch);
            pricePerUnit = ((sum * markup)/quantityOfBatch);
            PPU.text = ("PPU: " + pricePerUnit.ToString());

        }
    }
}
