﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Image image;

    public void SetFill(float amount)
    {

        image.fillAmount = amount;

    }

}
