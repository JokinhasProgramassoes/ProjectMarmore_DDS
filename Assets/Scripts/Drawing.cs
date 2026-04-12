using UnityEngine;
using UnityEngine.EventSystems;

public class Drawing : MonoBehaviour
{
    public Camera m_camera;

    [Header("Brushes")]
    public GameObject brushRed;
    public GameObject brushBlue;
    public GameObject brushGreen;
    public GameObject brushWhite;
    public GameObject brushYellow;
    public GameObject brushOrange;
    public GameObject brushPurpol;
    public GameObject brushBrown;

    [Header("Brush atual")]
    public int brushCount;

    [Header("Tamanho do pincel atual")]
    public float currentBrushSize = 0.1f;

    [Header("Tamanhos disponíveis")]
    public float smallBrushSize = 0.05f;
    public float mediumBrushSize = 0.1f;
    public float largeBrushSize = 0.2f;

    [Header("Opacidade atual")]
    [Range(0f, 1f)]
    public float currentAlpha = 1f;

    [Header("Limites do canvas")]
    public float canvaXMin = 0.0f;
    public float canvaXMax = 1.0f;
    public float canvaYMin = 0.0f;
    public float canvaYMax = 1.0f;

    [Header("Suavidade do traco")]
    public float minDistanceBetweenPoints = 0.02f;

    private LineRenderer currentLineRenderer;
    private Vector2 lastPos;

    void Update()
    {
        Draw();
    }

    bool TryGetInputPosition(out Vector2 screenPos)
    {
        if (Input.touchCount > 0)
        {
            screenPos = Input.GetTouch(0).position;
            return true;
        }

        screenPos = Input.mousePosition;
        return true;
    }

    bool InputStarted()
    {
        if (Input.touchCount > 0)
        {
            return Input.GetTouch(0).phase == TouchPhase.Began;
        }

        return Input.GetMouseButtonDown(0);
    }

    bool InputHeld()
    {
        if (Input.touchCount > 0)
        {
            TouchPhase phase = Input.GetTouch(0).phase;
            return phase == TouchPhase.Moved || phase == TouchPhase.Stationary;
        }

        return Input.GetMouseButton(0);
    }

    bool InputEnded()
    {
        if (Input.touchCount > 0)
        {
            TouchPhase phase = Input.GetTouch(0).phase;
            return phase == TouchPhase.Ended || phase == TouchPhase.Canceled;
        }

        return Input.GetMouseButtonUp(0);
    }

    bool IsPointerOverUI()
    {
        if (EventSystem.current == null) return false;

        if (Input.touchCount > 0)
        {
            return EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
        }

        return EventSystem.current.IsPointerOverGameObject();
    }

    Vector2 ScreenToWorld(Vector2 screenPos)
    {
        return m_camera.ScreenToWorldPoint(screenPos);
    }

    Vector2 GetClampedWorldPos(Vector2 screenPos)
    {
        Vector2 pos = ScreenToWorld(screenPos);

        pos.x = Mathf.Clamp(pos.x, canvaXMin, canvaXMax);
        pos.y = Mathf.Clamp(pos.y, canvaYMin, canvaYMax);

        return pos;
    }

    bool IsInsideCanvas(Vector2 pos)
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

    void PointToInputPos(Vector2 screenPos)
    {
        Vector2 pos = GetClampedWorldPos(screenPos);

        if (Vector2.Distance(lastPos, pos) > minDistanceBetweenPoints)
        {
            AddPoint(pos);
            lastPos = pos;
        }
    }

    void Draw()
    {
        if (!TryGetInputPosition(out Vector2 screenPos))
            return;

        Vector2 rawWorldPos = ScreenToWorld(screenPos);

        if (InputStarted())
        {
            if (IsPointerOverUI()) return;
            if (!IsInsideCanvas(rawWorldPos)) return;

            CreateBrush(screenPos);
        }
        else if (InputHeld())
        {
            if (currentLineRenderer == null) return;
            if (IsPointerOverUI()) return;

            if (!IsInsideCanvas(rawWorldPos))
            {
                currentLineRenderer = null;
                return;
            }

            PointToInputPos(screenPos);
        }
        else if (InputEnded())
        {
            currentLineRenderer = null;
        }
    }

    public void SmallBrushButton()
    {
        currentBrushSize = smallBrushSize;
    }

    public void MediumBrushButton()
    {
        currentBrushSize = mediumBrushSize;
    }

    public void LargeBrushButton()
    {
        currentBrushSize = largeBrushSize;
    }

public void SetAlpha(float value)
{
    currentAlpha = value;
    Debug.Log("Slider mexeu: " + value);
}

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

    public void WhiteButton()
    {
        brushCount = 3;
    }

    public void YellowButton()
    {
        brushCount = 4;
    }

    public void OrangeButton()
    {
        brushCount = 5;
    }

    public void BrownButton()
    {
        brushCount = 6;
    }

    public void PurpolButton()
    {
        brushCount = 7;
    }

    void CreateBrush(Vector2 screenPos)
    {
        GameObject selectedBrush = brushRed;

        switch (brushCount)
        {
            case 0:
                selectedBrush = brushRed;
                Debug.Log("Red");
                break;
            case 1:
                selectedBrush = brushGreen;
                Debug.Log("Green");
                break;
            case 2:
                selectedBrush = brushBlue;
                Debug.Log("Blue");
                break;
            case 3:
                selectedBrush = brushWhite;
                Debug.Log("White");
                break;
            case 4:
                selectedBrush = brushYellow;
                Debug.Log("Yellow");
                break;
            case 5:
                selectedBrush = brushOrange;
                Debug.Log("Orange");
                break;
            case 6:
                selectedBrush = brushBrown;
                Debug.Log("Brown");
                break;
            case 7:
                selectedBrush = brushPurpol;
                Debug.Log("Purpol");
                break;
        }

        GameObject brushInstance = Instantiate(selectedBrush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        currentLineRenderer.startWidth = currentBrushSize;
        currentLineRenderer.endWidth = currentBrushSize;

        Color startColor = currentLineRenderer.startColor;
        Color endColor = currentLineRenderer.endColor;

        startColor.a = currentAlpha;
        endColor.a = currentAlpha;

        currentLineRenderer.startColor = startColor;
        currentLineRenderer.endColor = endColor;

        Vector2 pos = GetClampedWorldPos(screenPos);

        currentLineRenderer.positionCount = 2;
        currentLineRenderer.SetPosition(0, pos);
        currentLineRenderer.SetPosition(1, pos);

        lastPos = pos;
    }
}