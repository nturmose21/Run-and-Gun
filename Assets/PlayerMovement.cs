using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public int maxJumps = 2;
    public Transform weaponHoldPoint; // A point on the player where the weapon will be held

    private Rigidbody2D rb;
    private int jumpCount;
    private bool facingRight = false;
    private GameObject weaponInRange = null; // The weapon the player is near
    private GameObject equippedWeapon = null; // The weapon the player has picked up

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip the player based on movement direction
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.W) && jumpCount < maxJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
        }

        if (rb.velocity.y == 0)
        {
            jumpCount = 0;
        }

        // Handle weapon pickup
        if (Input.GetKeyDown(KeyCode.E) && weaponInRange != null)
        {
            PickupWeapon();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    // Triggered when entering the weapon's collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weapon"))
        {
            weaponInRange = other.gameObject;
        }
    }

    // Triggered when exiting the weapon's collider
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Weapon"))
        {
            weaponInRange = null;
        }
    }

    // Pickup the weapon
    void PickupWeapon()
    {
        if (equippedWeapon != null)
        {
            Destroy(equippedWeapon); // Optionally destroy the old weapon
        }

        equippedWeapon = weaponInRange;
        weaponInRange = null;

        equippedWeapon.transform.SetParent(weaponHoldPoint);
        equippedWeapon.transform.localPosition = Vector3.zero;
        equippedWeapon.transform.localRotation = Quaternion.identity;

        // Disable the collider so the weapon can't be picked up again
        equippedWeapon.GetComponent<Collider2D>().enabled = false;
    }
}
