using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponPrefab; // Reference to the weapon prefab to equip
    private Collider2D weaponCollider;

    void Start()
    {
        // Get the BoxCollider2D component attached to this weapon
        weaponCollider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collision");
        // Check if the player collides with the weapon
        if (other.CompareTag("Player"))
        {
            Debug.Log("collision with player");

            // Set this weapon object as a child of the player
            transform.SetParent(other.transform);

            // Optionally, reset the position relative to the player or adjust it as needed
            transform.localPosition = new Vector2(0, 0); // Resets to the player's position

            // Disable the box collider when the weapon is picked up
            weaponCollider.enabled = false;
        }
    }
}
