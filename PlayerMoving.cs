using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerMoving : MonoBehaviour
{
    private bool isStartRunning = false;
    public static bool isFinish = false;

    private float speed = 0.2f;
    private float rotatingSpeed = 4f;
    private float screenWidth = 0f;
    private float screenSizeCoef = 1f;

    public GameObject playerModel;

    public Animator anim;

    //public MoneyLogic moneyLogicScript;
    public UIManager UIManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
        screenSizeCoef = (Screen.width - 200f) / 4.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isStartRunning)
        {
            isStartRunning = true;
            anim.SetBool("isWalking", true);
            UIManagerScript.TurnOffUI();    
        }
        else if (Input.GetMouseButton(0))
        {
            float mousePosX = Input.mousePosition.x - (screenWidth / 2f);
            playerModel.transform.localPosition = new Vector3(mousePosX / screenSizeCoef, playerModel.transform.localPosition.y, playerModel.transform.localPosition.z);
        }

        if (isStartRunning && !isFinish)
        {
            Vector3 dir = new Vector3(0, 0, speed);
            transform.Translate(dir);
        }
        else if (isFinish)
        {
            anim.SetBool("isWalking", false);
        }
    }

    public void MakeRightTurn()
    {
        StartCoroutine(RightTurning());
    }

    public void MakeLeftTurn()
    {
        StartCoroutine(LeftTurning());
    }

    private IEnumerator RightTurning()
    {
        if(transform.eulerAngles.y == 0f)
        {
            while(transform.eulerAngles.y < 89f)
            {
                transform.Rotate(0, rotatingSpeed, 0);
                yield return new WaitForSeconds(0.02f);
            }
            transform.rotation = Quaternion.Euler(0, 90f, 0);
        }
        else if (transform.eulerAngles.y == -90f)
        {
            while (transform.eulerAngles.y < -1f)
            {
                transform.Rotate(0, rotatingSpeed, 0);
                yield return new WaitForSeconds(0.02f);
            }
            transform.rotation = Quaternion.Euler(0, 0f, 0);
        }
    }
    private IEnumerator LeftTurning()
    {
        if (transform.localEulerAngles.y == 0f)
        {
            while(transform.localEulerAngles.y > -89f)
            {
                transform.Rotate(0, -rotatingSpeed, 0);
                yield return new WaitForSeconds(0.02f);
            }
            transform.rotation = Quaternion.Euler(0, -90f, 0);
        }
        else if (transform.localEulerAngles.y == 90f)
        {
            while (transform.localEulerAngles.y > 1f && transform.localEulerAngles.y <= 90f)
            {
                transform.Rotate(0, -rotatingSpeed, 0);
                yield return new WaitForSeconds(0.02f);
            }
            transform.rotation = Quaternion.Euler(0, 0f, 0);
        }
    }
}
