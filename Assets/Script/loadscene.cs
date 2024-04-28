using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loadscene : MonoBehaviour
{
    // Start is called before the first frame update
    public void mainmenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    // Update is called once per frame
    public void credit()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void playgame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
