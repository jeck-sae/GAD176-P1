using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugShortcuts : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
