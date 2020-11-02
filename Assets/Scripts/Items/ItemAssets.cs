using UnityEngine;

// Complementary class for the Item class
// It is used as a container for all sprites of the pick-up items to be used.
public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }

    public Sprite speedBuff;
    public Sprite healthPotion;
}
