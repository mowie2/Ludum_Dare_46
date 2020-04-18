using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class CharacterAnimation : MonoBehaviour
{
    private float previousheight;

    private Transform statIncreaseCanvas;

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
        statIncreaseCanvas = transform.Find("Text Canvas");
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }

        statIncreaseCanvas.eulerAngles = Vector3.zero;
    }
}