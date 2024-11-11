using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] private GameObject shield, invisibleCloak;
    private bool isShieldActivated, isInvisibleCloakActivated;
    public bool Shield
    {
        get
        {
            return shield;
        }
        set
        {
            isShieldActivated = value;
        }
    }
    public bool InvisibleCloak
    {
        get
        {
            return isInvisibleCloakActivated;
        }
        set
        {
            isInvisibleCloakActivated = value;
        }
    }
    private void Start()
    {
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        shield.SetActive(false);
        invisibleCloak.SetActive(false);
        isShieldActivated = false;
    }
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftShift)))
        {
            if (!isShieldActivated)
            {
                shield.SetActive(true);
                isShieldActivated = true;
            }
            else
            {
                shield.SetActive(false);
                isShieldActivated = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isInvisibleCloakActivated)
            {
                invisibleCloak.SetActive(true);
                isInvisibleCloakActivated = true;
            }
            else
            {
                invisibleCloak.SetActive(false);
                isInvisibleCloakActivated = false;
            }
        }
    }
    private void Invisible()
    {
       
    }
}
