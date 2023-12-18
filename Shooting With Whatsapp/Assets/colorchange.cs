using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class colorchange : MonoBehaviour
{
    public Image image;
   public void changecolor()
    {
        image.color = Random.ColorHSV();
    }
}
