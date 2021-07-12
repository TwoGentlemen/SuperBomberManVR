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
    [SerializeField] private InputActionProperty activateClockBombAction;

    [Space(3)]
    [Header("Игровые события")]
    [SerializeField] private UnityEvent onPressShoot;
    [SerializeField] private UnityEvent onActivateClockBomb;
    

    List<ClockBombExplosion> clockBombs = new List<ClockBombExplosion>();

    private void Start()
    {
        shootAction.action.performed += ShootAction;
        activateClockBombAction.action.performed += ActivateClockBomb;
    }

    public void AddClockBomb(ClockBombExplosion clockBomb)
    {
        clockBombs.Add(clockBomb);
    }

    IEnumerator CaskadExplosion()
    {
        foreach (var bombClock in clockBombs)
        {
            bombClock.ActivateClockExplosion();
            yield return new WaitForSeconds(0.5f);
        }

        clockBombs.Clear();
    }

    private void ActivateClockBomb(InputAction.CallbackContext obj)
    {
        if(Time.timeScale == 0) { return;}
        onActivateClockBomb?.Invoke();
        _ = StartCoroutine(CaskadExplosion());
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
