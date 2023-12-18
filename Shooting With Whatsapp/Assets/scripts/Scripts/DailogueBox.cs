using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogBoxController : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject successText;
    public GameObject FailureText;

    void Start()
    {
        dialogBox.SetActive(false);
        FailureText.SetActive(false);
        successText.SetActive(true);
    }

    public void EnableDialogBox()
    {
        dialogBox.SetActive(true);
    }

    public void DisableDialogBox()
    {
        dialogBox.SetActive(false);
    }
    public void EnableSuccessText()
    {
        FailureText.SetActive(false);
        successText.SetActive(true);
    }

    public void DisableSuccessText()
    {
        FailureText.SetActive(true);
        successText.SetActive(false);
    }
}
