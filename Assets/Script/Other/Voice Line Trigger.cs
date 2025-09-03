using UnityEngine;

public class VoiceLineTrigger : MonoBehaviour
{
    VoiceLines voiceLines;

    private void OnTriggerExit(Collider other)
    {
        voiceLines = GetComponentInParent<VoiceLines>();
        voiceLines.PlayVoiceLine();
        Destroy(gameObject);
    }
}
