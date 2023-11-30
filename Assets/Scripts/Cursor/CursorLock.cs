using UnityEngine;

public class CursorLock : MonoBehaviour
{
    [SerializeField] PauseMenu _pauseMenu;
    void Update()
    {
        if (!_pauseMenu)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
