using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerControll : MonoBehaviour
{
    [Header("Parametors")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float sensetivity = 60f;

    [Space(3)]
    [SerializeField] private Camera cameraPl;
    [Space(3)]
    [SerializeField] UnityEvent onShoot;

    [Space(3)]
    [SerializeField] InputActionProperty moveAction;
    [SerializeField] InputActionProperty rotateAction;
    [SerializeField] InputActionProperty shootAction;
    [SerializeField] InputActionProperty activateClockBombAction;

    List<ClockBombExplosion> clockBombs = new List<ClockBombExplosion>();

    public delegate void onChangeCountRoller(int countRoller);
    public event onChangeCountRoller onChangeCountRollerEvent; 

    private int countRoller = 1;
    private Rigidbody _rb;
    float eulerLimit = 60;

    float X = 0;

    private CharacterController character;

    private float startSpeed => moveSpeed;
 
    private void Start()
    {
        character = GetComponent<CharacterController>();
        _rb = GetComponent<Rigidbody>();
        shootAction.action.performed+=Shoot_performed;
        activateClockBombAction.action.performed += ActivateClockBomb;

        countRoller = GameManager.instance.PlayerStats.countRoller;
        moveSpeed += countRoller;
    }
    private void Update()
    {
        OnMove(moveAction.action.ReadValue<Vector2>());
        onRotate(rotateAction.action.ReadValue<Vector2>());
    }

    private void Shoot_performed(InputAction.CallbackContext obj)
    {
        onShoot.Invoke();
    }

    private void OnMove(Vector2 inputMovement)
    {     
        var velocity = (transform.forward * inputMovement.y + transform.right * inputMovement.x).normalized * moveSpeed * Time.deltaTime;
       // _rb.velocity = velocity;

        character.Move(velocity);
    }

    private void onRotate(Vector2 inputRotate)
    {
        inputRotate *= sensetivity * Time.deltaTime;

        X += inputRotate.y;
        X = Mathf.Clamp(X,-eulerLimit,eulerLimit);
        cameraPl.transform.localEulerAngles = new Vector3(-X,0,0);

        transform.Rotate(0, inputRotate.x, 0);
    }

    public void ResetSpeed()
    {
        moveSpeed = startSpeed;
        countRoller = 0;
        onChangeCountRollerEvent?.Invoke(countRoller);
        GameManager.instance.PlayerStats.countRoller = countRoller;
    }
    public void AddSpeed(float speed)
    {
        moveSpeed += speed;
        countRoller++;
        onChangeCountRollerEvent?.Invoke(countRoller);
        GameManager.instance.PlayerStats.countRoller = countRoller;
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
        if (Time.timeScale == 0) { return; }
        StopAllCoroutines();
        StartCoroutine(CaskadExplosion());
    }

    private void OnDestroy()
    {
        shootAction.action.performed -= Shoot_performed;
        activateClockBombAction.action.performed -= ActivateClockBomb;
    }
}
