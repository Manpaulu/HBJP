using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void QuitGameButton()
    {
        print("quit");
        Application.Quit();
    }
}
