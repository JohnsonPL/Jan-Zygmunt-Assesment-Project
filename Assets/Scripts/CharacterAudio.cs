using UnityEngine;

public class CharacterAudio : MonoBehaviour
{
    [SerializeField] AudioSource footstepsAudioSource = null;
    [SerializeField] AudioSource jumpingAudioSource = null;

    [Header("Audio Clips")]
    [SerializeField] AudioClip[] softSteps = null;
    [SerializeField] AudioClip[] hardSteps = null;
    [SerializeField] AudioClip softLanding = null;
    [SerializeField] AudioClip hardLanding = null;
    [SerializeField] AudioClip hardJump = null;
    [SerializeField] AudioClip softJump = null;

    [Header("Steps")]
    [SerializeField] float stepsTimeGap = 1f;

    private float stepsTimer;

    public void PlaySteps(GroundType groundType, float speedNormalized)
    {
        if (groundType == GroundType.None)
            return;

        stepsTimer += Time.fixedDeltaTime * speedNormalized;

        if (stepsTimer >= stepsTimeGap)
        {
            var steps = groundType == GroundType.Hard ? hardSteps : softSteps;
            int index = Random.Range(0, steps.Length);
            footstepsAudioSource.PlayOneShot(steps[index]);

            stepsTimer = 0;
        }
    }

    public void PlayJump(GroundType groundType)
    {
        if (groundType == GroundType.Hard)
            jumpingAudioSource.PlayOneShot(hardJump);
        else
            jumpingAudioSource.PlayOneShot(softJump);
    }

    public void PlayLanding(GroundType groundType)
    {
        if (groundType == GroundType.Hard)
            jumpingAudioSource.PlayOneShot(hardLanding);
        else
            jumpingAudioSource.PlayOneShot(softLanding);
    }
}

