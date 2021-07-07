using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerControllVR : MonoBehaviour
{
    [SerializeField] private ActionBasedContinuousMoveProvider moveControll;

    public void AddSpeed()
    {
        moveControll.moveSpeed+=0.2f;
        Debug.Log("Добавлена скорость");
    }
   
}
