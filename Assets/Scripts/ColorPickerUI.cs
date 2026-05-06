using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPickerUI : MonoBehaviour
{
    public Drawing drawing;

    public void RedButton()
    {
        drawing.brushCount = 0;
    }

    public void GreenButton()
    {
        drawing.brushCount = 1;
    }

    public void BlueButton()
    {
        drawing.brushCount = 2;
    }

    public void WhiteButton()
    {
        drawing.brushCount = 3;
    }

    public void YellowButton()
    {
        drawing.brushCount = 4;
    }

    public void OrangeButton()
    {
        drawing.brushCount = 5;
    }

    public void BrownButton()
    {
        drawing.brushCount = 6;
    }

    public void PurpolButton()
    {
        drawing.brushCount = 7;
    }

    public void PinkButton()
    {
        drawing.brushCount = 8;
    }

    public void BlackButton()
    {
        drawing.brushCount = 9;
    }

    public void DarkGreenButton()
    {
        drawing.brushCount = 10;
    }

    public void LightBlueButton()
    {
        drawing.brushCount = 11;
    }


}
