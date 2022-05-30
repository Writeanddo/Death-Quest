using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    [SerializeField] bool toggle;
    [SerializeField] GameObject panel;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggle = !toggle;
        }


        if (toggle)
        {
            panel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }

        else
        {

            Time.timeScale = 1;
            panel.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void resume()
    {
        toggle = !toggle;
    }

    public void mainmenu()
    {
        SceneManager.LoadScene(0);
    }
}
