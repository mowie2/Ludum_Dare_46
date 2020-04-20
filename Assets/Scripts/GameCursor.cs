using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCursor : MonoBehaviour
{
    public Texture2D cursorTexture;

    private Transform statCanvas;

    // Start is called before the first frame update
    private void Start()
    {
        statCanvas = GameObject.Find("Stat Circles").transform;
        Cursor.SetCursor(cursorTexture, new Vector2(20, 40), CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    private void Update()
    {
        statCanvas.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }
}