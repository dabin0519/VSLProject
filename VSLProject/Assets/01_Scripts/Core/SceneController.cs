using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoSingleton<SceneController>
{
    public void LoadScene(int idx)
    {
        SceneManager.LoadScene(idx);
    }
}
