using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    [SerializeField] private float _changingSpeed;
    private AudioSource _audioSource;
    private bool _isPlaying = false;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    private void Update()
    {
        if(_isPlaying)
            ChangeVolume(_audioSource.volume, 1);        
        if(_isPlaying == false)
            ChangeVolume(_audioSource.volume, 0);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Robber robber))
        {
            _isPlaying = true;
        }
    }
        
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Robber robber))
        {
            _isPlaying = false;
        }
    }

    private void ChangeVolume(float startVolume, float finalVolume)
    {
        _audioSource.volume = Mathf.MoveTowards(startVolume, finalVolume, _changingSpeed * Time.deltaTime);
    }
}
