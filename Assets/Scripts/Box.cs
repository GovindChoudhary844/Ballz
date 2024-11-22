using UnityEngine;
using TMPro; 

public class Box : MonoBehaviour
{
    public GameObject num; // Reference to the TextMeshPro GameObject
    private int gen; // Random number for the box
    private Animator animator;
    private bool isDestroyed = false;

    void Start()
    {
        // Generate a random number between 1 and 9
        gen = Random.Range(1, 10);

        animator = GetComponent<Animator>();

        // Update the displayed number initially
        UpdateText();
    }

    void Update()
    {
        // Continuously update the text display
        UpdateText();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDestroyed)
        {
            // Decrease the number on collision
            gen--;

            if (gen < 1)
            {
                TriggerBlast();
            }

        }
    }

    private void UpdateText()
    {
        // Safely update the TextMeshPro text if it's assigned and valid
        if (num != null)
        {
            TMP_Text textComponent = num.GetComponent<TMP_Text>();
            if (textComponent != null)
            {
                textComponent.text = gen.ToString();
            }
            else
            {
                Debug.LogError("'num' don't have a TMP_Text component.");
            }
        }
        else
        {
            Debug.LogError("'num' GameObject is not assigned.");
        }
    }

    private void TriggerBlast()
    {
        isDestroyed = true; //Prevent multiple destruction triggeres

        //Trigger the blact animation
        if (animator != null)
        {
            animator.SetTrigger("explode");
        }

        //Destroy the box once the nimation is finished
        Destroy(gameObject, 0.3f);
    }
}
