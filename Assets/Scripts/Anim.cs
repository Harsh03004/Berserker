using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{   
    [SerializeField] Animator animController;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animController.SetBool("Jump",true);

        }
        else if (!Input.GetKeyDown(KeyCode.Space))
        {
            animController.SetBool("Jump",false);
        }
    }
}
