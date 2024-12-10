using System.Collections;
using UnityEngine;

namespace DialogSystem
{
    public class DialogHolder : MonoBehaviour
    {
        public npcController npc; // Reference to the NPC controller

        private void Awake()
        {
            Deactivate(); // Deactivate all child dialogs at the start
        }

        public void StartDialogSequence()
        {
            StartCoroutine(DialogSequence());
        }

        private IEnumerator DialogSequence()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Deactivate();
                transform.GetChild(i).gameObject.SetActive(true); // Activate one dialog line at a time
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogLine>().finished); // Wait for typing to finish
            }

            if (npc != null)
            {
                npc.DialogFinished(); // Notify NPC when dialog finishes
            }

            gameObject.SetActive(false); // Optional: Disable DialogHolder when the sequence is done
        }

        private void Deactivate()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}