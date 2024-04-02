using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Quit : MonoBehaviour
{
    public void buttonClick()
    {
        Debug.Log("Click");
        Application.Quit();
    }

}
