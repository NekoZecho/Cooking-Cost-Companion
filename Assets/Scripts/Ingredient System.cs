using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class IngredientSystem : MonoBehaviour
{
    [SerializeField]
    TMP_InputField markupField;
    [SerializeField]
    TMP_InputField batchQuantity;
    [SerializeField]
    TMP_Text PPU;
    float markup;
    float quantityOfBatch;
    float pricePerUnit;
    GameObject[] Names;
    GameObject[] Costs;
    GameObject[] Qty;

 

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            findTheNumbers();
            calculateCosts();
            prepareToSave();

        }
    }

    private void calculateCosts()
    {
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
        pricePerUnit = ((sum / quantityOfBatch) * markup);
        PPU.text = ("PPU: " + pricePerUnit.ToString());
    }

    private void findTheNumbers()
    {
        Names = GameObject.FindGameObjectsWithTag("Name");
        Costs = GameObject.FindGameObjectsWithTag("Cost");
        Qty = GameObject.FindGameObjectsWithTag("Qty");
    }

    private void prepareToSave()
    {
        string namesList = "";
        Names = Names.OrderBy(n => n.name).ToArray();
        for (int i = 0; i < Names.Length; i++)
        {
            string name = "";
            name = Names[i].GetComponent<TMP_InputField>().text;
            if (name == "")
            {
                name = " ";
            }
            namesList += name + ",";
        }
        Debug.Log(namesList);

        string costsList = "";
        Costs = Costs.OrderBy(n => n.name).ToArray();
        for (int i = 0;i < Costs.Length;i++)
        {
            string cost = "";
            cost = Costs[i].GetComponent<TMP_InputField>().text;
            if (cost == "")
            {
                cost = " ";
            }
            costsList += cost + ",";
        }
        Debug.Log(costsList);

        string qtyList = "";
        Qty = Qty.OrderBy(n => n.name).ToArray();
        for (int i = 0;i < Qty.Length;i++)
        {
            string qty = "";
            qty = Qty[i].GetComponent<TMP_InputField>().text;
            if (qty == "")
            {
                qty = " ";
            }
            qtyList += qty + ",";
        }
        Debug.Log(qtyList);
    }
}
