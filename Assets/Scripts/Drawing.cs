using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class Drawing : MonoBehaviour
{
    public Camera m_camera;
    #region Cores dos Strokes
    public GameObject brushRed;
    public GameObject brushBlue;
    public GameObject brushGreen;
    public GameObject brushWhite;
    #endregion
    public int brushCount;

    LineRenderer currentLineRenderer;
    Vector2 lastPos;

    //Limite do canvas--------------------------
    public float canvaXMin = 0.0f, canvaXMax = 1.0f;
    public float canvaYMin = 0.0f, canvaYMax = 1.0f;
    
    void Update()
    {
        
        Draw();
    }

    Vector2 GetRawMousePos()
    {
        return m_camera.ScreenToWorldPoint(Input.mousePosition);
    }

    Vector2 GetClampedMousePos()
    {
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        //Clamp do tamanho do canvas:
        mousePos.x = Mathf.Clamp(mousePos.x, canvaXMin, canvaXMax);
        mousePos.y = Mathf.Clamp(mousePos.y, canvaYMin, canvaYMax); 

        return mousePos;
    }

    bool IsInsideCanvas (Vector2 pos)
    {
        return pos.x >= canvaXMin && pos.x <= canvaXMax &&
        pos.y >= canvaYMin && pos.y <= canvaYMax; 
    }

    void AddPoint(Vector2 pointPos)
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }

     void PointToMousePos()
    {
        Vector2 mousePos = GetClampedMousePos();
        
        if(lastPos != mousePos)
        {
            AddPoint(mousePos);
            lastPos = mousePos;
        }
    }


    void Draw()
    {
        Vector2 rawMousePos = GetRawMousePos();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            if (!IsInsideCanvas(rawMousePos)) return;
            
            if(brushCount == 0) CreateBrushRed();
            if(brushCount == 1) CreateBrushGreen();
            if(brushCount == 2) CreateBrushBlue();
            if(brushCount == 3) CreateBrushWhite();
        
        }

        else if (Input.GetKey(KeyCode.Mouse0))
        {
            if(currentLineRenderer == null) return;

            if (!IsInsideCanvas(rawMousePos))
            {
                currentLineRenderer = null;
                return;
            }

            PointToMousePos();
        }
        else
        {
            currentLineRenderer = null;
        }
    }

    #region EscolhaCor
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
    #endregion

    #region Brushes
    void CreateBrushRed()
    {
        GameObject brushInstance = Instantiate (brushRed);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        
        Vector2 mousePos = GetClampedMousePos();

        currentLineRenderer.positionCount = 2;
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);

        lastPos = mousePos;
    }

    void CreateBrushGreen()
    {
        GameObject brushInstance = Instantiate (brushGreen);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        
        Vector2 mousePos = GetClampedMousePos();

        currentLineRenderer.positionCount = 2;
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);

        lastPos = mousePos;
    }

    void CreateBrushBlue()
    {
        GameObject brushInstance = Instantiate (brushBlue);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        
        Vector2 mousePos = GetClampedMousePos();

        currentLineRenderer.positionCount = 2;
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);

        lastPos = mousePos;
    }

    void CreateBrushWhite()
    {
        GameObject brushInstance = Instantiate (brushWhite);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();
        
        Vector2 mousePos = GetClampedMousePos();

        currentLineRenderer.positionCount = 2;
        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);

        lastPos = mousePos;
    }
    #endregion
}
