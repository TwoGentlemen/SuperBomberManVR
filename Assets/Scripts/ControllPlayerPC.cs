using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllPlayerPC : MonoBehaviour
{
    [SerializeField] private Camera cameraPl; //Êàìåðà èãðîêà
    [SerializeField] private float moveSpeed = 3f; //Ñêîðîñòü ïåðåäâèæåíèÿ
    [SerializeField] private float mouseSpeed = 50f; //×óâñòâèòåëüíîñòü ìûøè
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnPointShoot;

    private Rigidbody _rb;
    private PlControl _inputs;

    private void Awake() => _inputs = new PlControl();
    private void OnEnable() => _inputs.Enable();
    private void OnDisable() => _inputs.Disable();
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
       // _inputs.Player.Shoot.performed += Shoot_performed;
    }

    private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Shoot();
    }

    private void Update()
    {
        OnMove(_inputs.Player.Move.ReadValue<Vector2>());
        onRotate(_inputs.Player.Mouse.ReadValue<Vector2>());
    }
    public void OnMove(Vector2 inputMovement)
    {
        var velocity = (transform.forward * inputMovement.y + transform.right * inputMovement.x).normalized * moveSpeed * Time.deltaTime;
        _rb.velocity = velocity;
    }

    public void onRotate(Vector2 inputRotate)
    {
        inputRotate *= mouseSpeed * Time.deltaTime;

        cameraPl.transform.Rotate(-inputRotate.y, 0, 0);//Ïîâîðîò êàìåðû
        transform.Rotate(0, inputRotate.x, 0); //Ïîâîðîò òåëà èãðîêà
    }

    private void Shoot()
    {
        
        //var _bullet = Instantiate(bullet, spawnPointShoot.position, Quaternion.identity);
        //var rb = _bullet.GetComponent<Rigidbody>();
        //var explosion = _bullet.GetComponent<BombExplosion>();

        //if (!rb || !explosion) { Debug.LogError("Not found Rigidbody or BombExplosion"); return; }


        //explosion.ExplosionActivate(3); //Àêòèâèðóåì âçðûâ ñíàðÿäà ïî òàéìåðó
        //rb.AddForce(transform.forward * 20, ForceMode.Impulse);
    }
}
