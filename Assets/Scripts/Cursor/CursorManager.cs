using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

  // You must set the cursor in the inspector.
  public Texture2D cursor;
  public Material material;

    void Start()
    {

        //set the cursor origin to its centre. (default is upper left corner)
        Vector2 cursorOffset = new Vector2(cursor.width / 2, cursor.height / 2);

        //Sets the cursor to the Crosshair sprite with given offset 
        //and automatic switching to hardware default if necessary
        Cursor.SetCursor(cursor, cursorOffset, CursorMode.Auto);
        

        
    }
}

