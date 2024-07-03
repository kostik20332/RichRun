using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject[] startUI;
    public GameObject[] gameUI;

    public GameObject finishUI;

    public TMP_Text finishMoneyAmountText;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    public void TurnOffUI()
    {
        for(int i = 0; i < startUI.Length; i++)
        {
            startUI[i].SetActive(false);
        }
        for(int i = 0; i < gameUI.Length; i++)
        {
            gameUI[i].SetActive(true);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void FinishActivation(int moneyAmount)
    {
        finishUI.SetActive(true);
        finishMoneyAmountText.text = "" + moneyAmount;
    }
}
