using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    private int moneyAmount = 30;

    public Image moneyBar;

    public UIManager UIManagerSCript;

    // Update is called once per frame
    void Update()
    {
        moneyBar.fillAmount = moneyAmount / 100f;
    }

    private void healthChange(int healthDelta)
    {
        Debug.LogWarning(healthDelta);
        moneyAmount += healthDelta;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Money")
        {
            healthChange(3);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Alcogol")
        {
            healthChange(-10);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Finish")
        {
            UIManagerSCript.FinishActivation(moneyAmount);
            PlayerMoving.isFinish = true;
        }
    }
}
