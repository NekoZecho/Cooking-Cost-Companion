using System.Collections;
using System.Collections.Generic;
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


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Names = GameObject.FindGameObjectsWithTag("Name");
            Costs = GameObject.FindGameObjectsWithTag("Cost");
            Qty = GameObject.FindGameObjectsWithTag("Qty");
            Debug.Log(Names[0]);
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
            string namesList = "";
            for (int i = 0; i < Names.Length; i++)
            {
                string name = "";
                Debug.Log(Names[i].GetComponent<TMP_InputField>().text);
                name = Names[i].GetComponent<TMP_InputField>().text;
                namesList += name + ",";
            }
            Debug.Log(namesList);

        }
    }
}
