using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public partial class Player : MonoBehaviour
{
    // For future player reference
    public static Player instance;

    private bool isInvincible = false;
    public float invincibleDurationSec;
    public float invincibleDeltaTime;
    public GameObject model;
    public Vector3 baseScale = new Vector3(.2f, .2f);
    public Vector3 invincibleScale = new Vector3(.001f, .001f);
    public Transform startLocation;

    public int currentHearts;
    public int totalHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Loading loadCheck;

    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        instance = this;
        setInventory();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        loadCheck = GameObject.FindObjectOfType<Loading>();
        StartCoroutine("fixStartingPosition");
    }

    void Update()
    {
        if (loadCheck.Loaded)
        {
            // Handle movement depending on keyboard inputs
            Move(moveInput);

            // Handle inventory 
            toggleInventory();

            //Create the health bar
            DrawHealthBar();
        }
    }

    void FixedUpdate()
    {
        updatePosition();

        if (moveInput.x != 0 || moveInput.y != 0)
        {
            //Animate player while moving
            Animate(moveInput);
        }
        else
        {
            //If not moving set to idle
            anim.SetLayerWeight(1, 0);
        }
    }

    void SetModelScale(Vector3 scale)
    {
        model.transform.localScale = scale;
    }

    public void Respawn()
    {
        transform.position = startLocation.position;
    }

    IEnumerator fixStartingPosition()
    {
        yield return new WaitForSeconds(2f);
        transform.position = new Vector3(0, 0, 0);
    }
}
