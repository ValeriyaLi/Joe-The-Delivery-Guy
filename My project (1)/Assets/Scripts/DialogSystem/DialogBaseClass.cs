using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DialogSystem
{
    public class DialogBaseClass : MonoBehaviour
    {
        public bool finished { get; private set; }
        protected IEnumerator WriteText(string input, TextMeshProUGUI textHolder, float delay, AudioClip audio)
        {
            finished = false; // Reset the finished flag
            textHolder.text = ""; // Clear any existing text

            for (int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];
                if (audio != null)
                {
                    SoundManager.instance.PlaySound(audio);
                }
                yield return new WaitForSeconds(delay);
            }

            yield return new WaitForSeconds(0.5f); // Optional pause after typing is complete
            finished = true;
        }

    }
}

