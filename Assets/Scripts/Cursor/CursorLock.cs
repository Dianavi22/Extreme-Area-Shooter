using UnityEngine;

public class CursorLock : MonoBehaviour
{

    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
}
