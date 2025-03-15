using UnityEngine;

[DefaultExecutionOrder(-99)]
public class AudioManager : SingletonMonoBehavior<AudioManager>
{
    [Header("--- Audio Source ---")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("--- Audio Clip ---")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip wall;
    public AudioClip brick;
    public AudioClip shoot;

    protected override void Awake()
    {
        base.Awake();

        if (musicSource != null && background != null)
        {
            musicSource.clip = background;
            musicSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (SFXSource != null && clip != null)
        {
            SFXSource.PlayOneShot(clip);
        }
    }
}
