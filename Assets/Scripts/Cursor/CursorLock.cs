using UnityEngine;

public class CursorLock : MonoBehaviour
{
    void Update()
    {
        if (!PauseMenu.gameIsPaused)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
