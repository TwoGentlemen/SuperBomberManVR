using UnityEngine;
using UnityEngine.InputSystem;


using NEW;
public class PlayerControll : MonoBehaviour
{
    [Header("Parametors")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float sensetivity = 60f;

    [Space(10)]
    [SerializeField] private Camera cameraPl;
    [SerializeField] private CharacterController character;

    [Space(20)]
    [SerializeField] InputActionProperty moveAction;
    [SerializeField] InputActionProperty rotateAction;
    [SerializeField] InputActionProperty shootAction;
    [SerializeField] InputActionProperty activateClockBombAction;


    //For rotate camera
    private float _eulerLimit = 60; //Limit on rotate up and down
    private float _rotate_X = 0;

    [SerializeField] private bool isStartGame = true; 
    private SpawnBomb spawnBomb;

    private void OnEnable()
    {
        
    }
    private void Start()
    {
        character = GetComponent<CharacterController>();
        spawnBomb = GetComponent<SpawnBomb>();

        if(spawnBomb == null || character == null)
        {
            Debug.LogError("Not spawn bomb");
        }
        //----Subscribe events----
        if(Player.instanstance == null || GameManager.instance == null) { return;}
        Player.instanstance.changeMoveSpeedAction += ChangeMoveSpeedAction;
        GameManager.instance.onStartGame += OnStartGame;
        shootAction.action.performed += ShootAction;
    }

    private void ShootAction(InputAction.CallbackContext obj)
    {
        if (isStartGame) { return; }
        spawnBomb.PlantBomb();
    }

    private void OnStartGame()
    {
        isStartGame = false;
    }

    private void ChangeMoveSpeedAction(float value)
    {
        moveSpeed = value;
    }

    private void Update()
    {
        if (isStartGame) { return; }

        OnMove(moveAction.action.ReadValue<Vector2>());
        OnRotate(rotateAction.action.ReadValue<Vector2>());
    }

   

    private void OnMove(Vector2 inputMovement)
    {     
        var velocity = (transform.forward * inputMovement.y + transform.right * inputMovement.x).normalized * moveSpeed * Time.deltaTime;
        character.Move(velocity);
    }

    private void OnRotate(Vector2 inputRotate)
    {
        inputRotate *= sensetivity * Time.deltaTime;

        _rotate_X += inputRotate.y;
        _rotate_X = Mathf.Clamp(_rotate_X,-_eulerLimit,_eulerLimit);
        cameraPl.transform.localEulerAngles = new Vector3(-_rotate_X,0,0);

        transform.Rotate(0, inputRotate.x, 0);
    }
    


    private void OnDestroy()
    {
        if (Player.instanstance == null || GameManager.instance == null) { return; }
        Player.instanstance.changeMoveSpeedAction -= ChangeMoveSpeedAction;
        NEW.GameManager.instance.onStartGame -= OnStartGame;
        shootAction.action.performed -= ShootAction;
    }
}
