using UnityEngine;

public class MercuryInteraction : MonoBehaviour
{
    public GameObject infoPanel;
    public GameObject interactText;

    private bool playerNear = false;

    void Start()
    {
        infoPanel.SetActive(false);
        interactText.SetActive(false);
    }

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            infoPanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            infoPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;

            interactText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;

            interactText.SetActive(false);

            infoPanel.SetActive(false);
        }
    }
}