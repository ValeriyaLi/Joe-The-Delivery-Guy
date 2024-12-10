using UnityEngine;

public class npcController : MonoBehaviour
{
    [SerializeField] public DialogSystem.DialogHolder dialogHolder;

    public void ActivateDialog()
    {
        if (dialogHolder != null)
        {
            Debug.Log("Starting dialog sequence...");
            dialogHolder.npc = this; // Assign this NPC to the dialog holder
            dialogHolder.StartDialogSequence();
        }
        else
        {
            Debug.LogError("DialogHolder is not assigned to the NPC!");
        }
    }

    public void DialogFinished()
    {
        Debug.Log("Dialog finished. Destroying NPC...");
        Destroy(gameObject); // Destroy the NPC when dialog finishes
    }
}