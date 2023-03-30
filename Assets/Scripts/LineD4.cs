using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineD4 : MonoBehaviour
{
    // Audio clip for the pitch of the line
    public AudioClip linePitch;

    // Play the pitch of the line when the note collides with the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("D4"))
        {
            AudioSource.PlayClipAtPoint(linePitch, transform.position);
        }
    }
}
