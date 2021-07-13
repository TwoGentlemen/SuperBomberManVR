using UnityEngine;


[RequireComponent(typeof (AudioSource))]
public class BombExplossion : MonoBehaviour
{
    [Header("’арактеристики бомбы")]
    [SerializeField] private int fireLength = 1;   
    [SerializeField] private float time = 3;
    [SerializeField] private Transform body;

    [Header("Ёффекты при взрыве")]
    [SerializeField] private GameObject effect; 

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = GameManager.instance.AudioManager.GetAydioBabax();
        ActivateExplosion();
    }

    protected virtual void ActivateExplosion()
    {
        Invoke("Explosion", time);
    }

    protected virtual void Explosion()
    {
        GridManager.instance.Explosion(transform.position);
        GridManager.instance.SetObjectInCell(null,GridManager.instance.GetIndexCell(gameObject.transform.position));

        audioSource.Play();
        body.gameObject.SetActive(false);
        var ex = Instantiate(effect, transform.position,Quaternion.identity);
        Destroy(ex,1f);
        Destroy(gameObject,audioSource.clip.length);
    }
}  

