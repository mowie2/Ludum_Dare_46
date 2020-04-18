using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private float previousheight;

    private void Start()
    {
    }

    private void LateUpdate()
    {
        if (IsFalling())
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Character/Character");
        }
    }

    private bool IsFalling()
    {
        float currentheight = transform.position.y;
        float travel = currentheight - previousheight;

        previousheight = currentheight;
        return travel < 0;
    }
}