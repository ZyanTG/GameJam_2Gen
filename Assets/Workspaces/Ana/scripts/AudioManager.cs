
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    
    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Range(0f, 1f)]
    public float sfxVolume = 0.3f;


    [Header("Ambient Sounds")]
    public AudioClip mainMenuAmbience;
    public AudioClip whiteWorldAmbience;
    public AudioClip darkWorldAmbience;

    [Header("UI Sounds")]
    public AudioClip uiClick;

    [Header("Gameplay Sounds")]
    public AudioClip badObjectHit;
    public AudioClip bombHit;
    public AudioClip gameOver;
    public AudioClip goodObjectHit01;
    public AudioClip goodObjectHit02;

    [Header("Transition Sounds")]
    public AudioClip worldGlitch;

    // AMBIENT SOUND

    public void PlayMainMenuAmbience()
    {
        PlayMusic(mainMenuAmbience);
    }

    public void PlayWhiteWorldAmbience()
    {
        PlayMusic(whiteWorldAmbience);
    }

    public void PlayDarkWorldAmbience()
    {
        PlayMusic(darkWorldAmbience);
    }

    private void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    // UI

    public void PlayUIClick()
    {
        PlaySFX(uiClick);
    }

    // GAMEPLAY

    public void PlayBadObjectHit()
    {
        PlaySFX(badObjectHit);
    }

    public void PlayBombHit()
    {
        PlaySFX(bombHit);
    }

    public void PlayGameOver()
    {
        PlaySFX(gameOver);
    }

    public void PlayGoodObjectHit01()
    {
        PlaySFX(goodObjectHit01);
    }

    public void PlayGoodObjectHit02()
    {
        PlaySFX(goodObjectHit02);
    }

    // TRANSITIONS

    public void PlayWorldGlitch()
    {
        PlaySFX(worldGlitch);
    }

    private void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;

        sfxSource.PlayOneShot(clip, sfxVolume);
    }
}
