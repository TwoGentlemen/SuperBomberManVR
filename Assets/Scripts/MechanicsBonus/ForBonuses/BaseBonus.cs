using UnityEngine;

[RequireComponent(typeof (AudioSource))]
public class BaseBonus : MonoBehaviour
{
    [Space(5)]
    [Tooltip("Particles take bonus")]
    [SerializeField] private GameObject effectTakeBonus;

    [Space(5)]
    [Tooltip("Audio clip play take bonus")]
    [SerializeField] private AudioClip audioTakeBonus;

    
    private AudioSource audioSource;
    [SerializeField] private Transform bodyObj;
    private Collider collider;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;

        collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) { return;}

        BehaviourBonus();
        GridManager.instance.SetObjectInCell(null, GridManager.instance.GetIndexCell(transform.position));//Clear cell with bonus

        //Spawn particles take bonus
       // var ef = Instantiate(effectTakeBonus,transform.position,transform.rotation);
      //  Destroy(ef,ef.GetComponent<ParticleSystem>().main.startDelayMultiplier);

        //Play audio take bonus
        audioSource.clip = audioTakeBonus;
        audioSource.Play();

        //Deactivation bonus
        collider.enabled = false;
        bodyObj.gameObject.SetActive(false);

        Destroy(gameObject, audioTakeBonus.length);
    }

    protected virtual void BehaviourBonus()
    {
        
    }
}
