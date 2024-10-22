using UnityEngine;
using TMPro;
public class GetInputFieldValue : MonoBehaviour
{
    [SerializeField]
    TMP_InputField flour;
    [SerializeField]
    TMP_InputField flourCost;
    [SerializeField]
    TMP_InputField flourProfit;
    [SerializeField]
    TMP_InputField batchQuantity;
    [SerializeField]
    TMP_Text PPU;
    float flourAmt;
    float cost;
    float profitMargin;
    float quantityOfBatch;
    float pricePerUnit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cost = PlayerPrefs.GetFloat("Flour Cost");
        flourCost.text = (cost.ToString());
        flourAmt = PlayerPrefs.GetFloat("Flour Amount");
        flour.text = (flourAmt.ToString());
        quantityOfBatch = PlayerPrefs.GetFloat("Units Per Batch");
        batchQuantity.text = (quantityOfBatch.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            float.TryParse(flourCost.text, out cost);
            PlayerPrefs.SetFloat("Flour Cost", cost);
            float.TryParse(flour.text, out flourAmt);
            PlayerPrefs.SetFloat("Flour Amount", flourAmt);
            float.TryParse(flourProfit.text, out profitMargin);
            PlayerPrefs.SetFloat("Profit Margin", profitMargin);
            float.TryParse(batchQuantity.text, out quantityOfBatch);
            PlayerPrefs.SetFloat("Units Per Batch", quantityOfBatch);
            pricePerUnit = ((flourAmt * cost) * profitMargin) / quantityOfBatch;
            PlayerPrefs.SetFloat("Price Per Unit", pricePerUnit);
            PPU.text = (pricePerUnit.ToString());
        }
    }
}
