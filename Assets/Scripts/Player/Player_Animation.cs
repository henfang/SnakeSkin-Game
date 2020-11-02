using UnityEngine;

public partial class Player
{
    void Animate(Vector2 direction)
    {
        anim.SetLayerWeight(1, 1);

        anim.SetFloat("x", direction.x);
        anim.SetFloat("y", direction.y);
    }
}
