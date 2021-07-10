using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerControllVR : MonoBehaviour
{

    [SerializeField] private ActionBasedContinuousMoveProvider moveControll;
    [SerializeField] private InputActionProperty shootAction;

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
        Debug.Log("��������� ��������");
    }
   
}
