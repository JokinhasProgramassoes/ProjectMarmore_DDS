using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour
{
    public Camera m_camera;
    public GameObject brushRed;
    public GameObject brushBlue;
    public GameObject brushGreen;
    public GameObject brushWhite;

    public int brushCount;

    LineRenderer currentLineRenderer;

    Vector2 lastPos;

    void Update()
    {
        Draw();
    }

    void AddPoint(Vector2 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }

    void PointToMousePos()
    {
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        if(lastPos != mousePos)
        {
            AddPoint(mousePos);
            lastPos = mousePos;
        }
    }


    void Draw()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(brushCount == 0)
            {
                //CreateBrushRed();
            }

             if(brushCount == 1)
            {
                //CreateBrushGreen();
            }

             if(brushCount == 2)
            {
                //CreateBrushBlue();
            }

             if(brushCount == 3)
            {
                //CreateBrushWhite();
            }
        }

        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PointToMousePos();
        }
        else
        {
            currentLineRenderer = null;
        }
    }

    //Buttons - defernetes cores:
    public void RedButton()
    {
        brushCount = 0;
    } 
    public void GreenButton()
    {
        brushCount = 1;
    } 
    public void BlueButton()
    {
        brushCount = 2;
    } 
    public void whiteButton()
    {
        brushCount = 3;
    } 

    void CreateBrushRed()
    {
        GameObject brushInstance = Instantiate (brushRed);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        // 2 pontos fazem uma linha:
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }

    void CreateBrushGreen()
    {
        GameObject brushInstance = Instantiate (brushGreen);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        // 2 pontos fazem uma linha:
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }

    void CreateBrushBlue()
    {
        GameObject brushInstance = Instantiate (brushBlue);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        // 2 pontos fazem uma linha:
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }

    void CreateBrushWhite()
    {
        GameObject brushInstance = Instantiate (brushWhite);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        // 2 pontos fazem uma linha:
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }
}
