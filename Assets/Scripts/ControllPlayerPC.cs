using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControllPlayerPC : MonoBehaviour
{
    //[SerializeField] private Camera cameraPl; 
    //[SerializeField] private float moveSpeed = 3f; 
    //[SerializeField] private float mouseSpeed = 50f; 
    //[SerializeField] UnityEvent onShoot;

    //private Rigidbody _rb;
    //private PlControl _inputs;

    //private void Awake() => _inputs = new PlControl();
    //private void OnEnable() => _inputs.Enable();
    //private void OnDisable() => _inputs.Disable();
    //private void Start()
    //{
    //    _rb = GetComponent<Rigidbody>();
    //    _inputs.Player.Shoot.performed += Shoot_performed;
    //}

    //private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    //{
    //    onShoot.Invoke();
    //}

    //private void Update()
    //{
    //    OnMove(_inputs.Player.Move.ReadValue<Vector2>());
    //    onRotate(_inputs.Player.Mouse.ReadValue<Vector2>());
    //}
    //public void OnMove(Vector2 inputMovement)
    //{
    //    var velocity = (transform.forward * inputMovement.y + transform.right * inputMovement.x).normalized * moveSpeed * Time.deltaTime;
    //    _rb.velocity = velocity;
    //}

    //public void onRotate(Vector2 inputRotate)
    //{
    //    inputRotate *= mouseSpeed * Time.deltaTime;

    //    cameraPl.transform.Rotate(-inputRotate.y, 0, 0);
    //    transform.Rotate(0, inputRotate.x, 0); 
    //}

    //public void AddSpeed(float speed) 
    //{

    //    moveSpeed += speed;
    //}

}
