using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotateLogic : MonoBehaviour
{
    public PlayerMoving playerMovingScript;

    public Animator[] flagAnims;

    private int nextFlagNumber = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RightTurn")
        {
            playerMovingScript.MakeRightTurn();
        }
        else if (other.gameObject.tag == "LeftTurn")
        {
            playerMovingScript.MakeLeftTurn();
        }
        else if (other.gameObject.tag == "FlagsOpen")
        {
            flagAnims[nextFlagNumber++].SetTrigger("isOpenning");
        }
    }
}
