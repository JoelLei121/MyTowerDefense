using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    public Text MoneyText;

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
