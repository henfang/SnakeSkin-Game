using UnityEngine;

public class healthBar : MonoBehaviour
{
    Vector3 localScale;
    public static healthBar Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        localScale = transform.localScale;
    }

    void Update()
    {
        localScale.x = Player.currentHealth / 100;
        transform.localScale = localScale;
    }

    public void Refresh()
    {
        localScale.x = Player.currentHealth / 100;
        transform.localScale = localScale;
    }
}
