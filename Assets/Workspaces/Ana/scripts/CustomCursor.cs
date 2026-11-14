
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture2D G_Cursor_Basic2_G;

    void Start()
    {
        Cursor.SetCursor(
            G_Cursor_Basic2_G,
            Vector2.zero,
            CursorMode.ForceSoftware
        );

        Cursor.visible = true;
    }
}
