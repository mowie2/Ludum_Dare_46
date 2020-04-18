using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CharacterAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private float previousheight;

    private bool IsFalling()
    {
        float currentheight = transform.position.y;
        float travel = currentheight - previousheight;

        previousheight = currentheight;
        return travel < 0;
    }

    private void LateUpdate()
    {
        if (IsFalling())
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Character/Character");
            gameObject.transform.Find("Jump Flames Light").GetComponent<Light2D>().enabled = false;
        }
    }

    private void Start()
    {
    }
}