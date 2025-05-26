using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------- Audio Clip ----------")]
    public AudioClip introMusic;
    public AudioClip waterDrip;
    public AudioClip coin;
    public AudioClip endingMusic;

    private void Start()
    {
        musicSource.clip = introMusic;
        musicSource.Play();
        SFXSource.clip = waterDrip;
        SFXSource.Play();
    }
}
