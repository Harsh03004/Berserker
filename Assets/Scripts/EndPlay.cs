using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class EndPlay : MonoBehaviour
{
    public void buttonClick()
    {
        Debug.Log("Click");
        SceneManager.LoadScene(1);
    }

}
