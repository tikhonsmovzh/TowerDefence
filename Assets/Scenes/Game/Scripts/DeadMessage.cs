using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMessage : MonoBehaviour
{
    public void Ok()
    {
        SceneManager.LoadScene(0);
        gameObject.SetActive(false);
    }
}
