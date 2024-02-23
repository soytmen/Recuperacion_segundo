using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenes: MonoBehaviour
{
    public void LoadGame(int escena)
    {
       
        UnityEngine.SceneManagement.SceneManager.LoadScene(escena);
    }
}
