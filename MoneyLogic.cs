using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyLogic : MonoBehaviour
{
    public TMP_Text moneyAmountText;

    private static int moneyAmount = 120;

    // Start is called before the first frame update
    void Start()
    {
        moneyAmountText.text = "" + moneyAmount;
    }

    public void AddMoney(int moneyAmountToAdd)
    {
        moneyAmount += moneyAmountToAdd;
        moneyAmountText.text = "" + moneyAmount;
    }
}
