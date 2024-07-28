using System.Collections;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private Animator animatorLight;

    private void Update()
    { 
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A) 
            || Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space))
            animatorLight.SetBool("LightMove", true);
        else
            animatorLight.SetBool("LightMove", false);
    }
}

