using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPanel : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
