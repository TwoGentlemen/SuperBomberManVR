using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerControllVR : MonoBehaviour
{
    [SerializeField] private ActionBasedContinuousMoveProvider moveControll;

    [Space(3)]
    [Header("Настройки управления")]
    [SerializeField] private InputActionProperty shootAction;

    [Space(3)]
    [Header("Игровые события")]
    [SerializeField] private UnityEvent onPressShoot;
    private void Start()
    {
        shootAction.action.performed += ShootAction;
    }

    private void ShootAction(InputAction.CallbackContext obj)
    {
        onPressShoot?.Invoke();
    }

    public void AddSpeed()
    {
        moveControll.moveSpeed+=0.2f;
    }
   
}
