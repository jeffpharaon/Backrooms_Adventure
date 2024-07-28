using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class LampSoundsSettings : MonoBehaviour
{
    [SerializeField] private string tagPlayer;
    [SerializeField] AudioClip[] sounds;
    private AudioSource source => GetComponent<AudioSource>();

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagPlayer)
        {
            source.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagPlayer)
        {
            PlaySound(sounds[0]);
        }
    }

    public void PlaySound(AudioClip clip, float volume = 1f, bool destroyed = false, float p1 = 1f)
    {
        source.pitch = p1;
        source.PlayOneShot(clip, volume);
    }
}
