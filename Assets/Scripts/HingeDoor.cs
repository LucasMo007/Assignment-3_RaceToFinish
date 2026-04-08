using UnityEngine;
using UnityEngine.UI;

public class HingeDoor : MonoBehaviour
{
    public int requiredKeyLevel = 1;
    public Text popupText; // UI text for messages
    public float openForce = 200f;

    private HingeJoint hinge;
    private bool isOpen = false;
    private bool playerInRange = false;
    private PlayerKeys playerKeys;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        if (popupText != null)
            popupText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (playerKeys != null && playerKeys.HasKey(requiredKeyLevel))
            {
                OpenDoor();
            }
            else
            {
                ShowPopup("Need Key Level " + requiredKeyLevel + "!");
            }
        }
    }

    void OpenDoor()
    {
        if (isOpen) return;
        isOpen = true;

        // Remove hinge limits to let door swing open
        hinge.useLimits = false;

        // Push door open
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * openForce);

        ShowPopup("Door Opened!");
        Invoke("HidePopup", 2f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerKeys = other.GetComponentInParent<PlayerKeys>();
            ShowPopup("Press E to open");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            HidePopup();
        }
    }

    void ShowPopup(string message)
    {
        if (popupText != null)
        {
            popupText.gameObject.SetActive(true);
            popupText.text = message;
        }
    }

    void HidePopup()
    {
        if (popupText != null)
            popupText.gameObject.SetActive(false);
    }
}
