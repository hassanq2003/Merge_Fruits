using UnityEngine;
using UnityEngine.UI;

public class PowerUpScript : MonoBehaviour
{
    public bool isPowerUpSelected = false;
    public bool isRemoveModeSelected = false;

    [SerializeField] private Button Remove_Fruit_button;
    [SerializeField] private Color activeColor = new Color(1f, 0.5f, 0.5f, 1f); // Dimmer color when activated
    [SerializeField] private Color inactiveColor = new Color(1f, 1f, 1f, 1f); // Default color when not activated

    void Start()
    {
        isRemoveModeSelected = false;
        isPowerUpSelected = false;
        UpdateButtonColor();
    }

    void Update()
    {
        Debug.Log(isPowerUpSelected);
        Debug.Log("remove " + isRemoveModeSelected);
        Handle_Power_Up_Functionality();
    }

    private void Handle_Power_Up_Functionality()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPowerUpSelected && isRemoveModeSelected)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {
                    GameObject clickedObject = hit.collider.gameObject;

                    if (clickedObject.GetComponent<Rigidbody2D>().isKinematic == false)
                    {
                        Debug.Log("hello");
                        Remove_Fruit(clickedObject);
                    }
                }
            }
        }
    }

    public void Toggle_Remove_Fruit_Mode()
    {
        isPowerUpSelected = !isPowerUpSelected;
        isRemoveModeSelected = !isRemoveModeSelected;
        UpdateButtonColor();
    }

    private void UpdateButtonColor()
    {
        if (isRemoveModeSelected)
        {
            Remove_Fruit_button.image.color = activeColor;
        }
        else
        {
            Remove_Fruit_button.image.color = inactiveColor;
        }
    }

    private void Remove_Fruit(GameObject gameObject)
    {
        Destroy(gameObject);
        Toggle_Remove_Fruit_Mode();
        FindObjectOfType<Score_Manager>().score -= 500;
    }
}
