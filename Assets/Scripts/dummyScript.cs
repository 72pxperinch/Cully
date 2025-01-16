using UnityEngine;
using System.Collections;

public class Dummy : MonoBehaviour
{
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;
    private CameraAnchor anchor;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anchor = GetComponent<CameraAnchor>();
    }

    private void Update()
    {
        HandleTouchInput();

        HandleSpriteInput(KeyCode.A, 0);
        HandleSpriteInput(KeyCode.S, 1);
        HandleSpriteInput(KeyCode.D, 2);
        HandleSpriteInput(KeyCode.F, 3);

        HandlePositionInput(KeyCode.H, new Vector3(-2.1f, -4f, 0));
        HandlePositionInput(KeyCode.J, new Vector3(-0.7f, -4f, 0));
        HandlePositionInput(KeyCode.K, new Vector3(0.7f, -4f, 0));
        HandlePositionInput(KeyCode.L, new Vector3(2.1f, -4f, 0));
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            MoveToPosition(touchPosition);
            Debug.Log("Touch input detected at position: " + touchPosition);
        }
    }


    private void HandleSpriteInput(KeyCode keyCode, int spriteIndex)
    {
        if (Input.GetKeyDown(keyCode))
        {
            ChangeSprite(sprites[spriteIndex]);
        }
    }

    private void HandlePositionInput(KeyCode keyCode, Vector3 newPos)
    {
        if (Input.GetKeyDown(keyCode))
        {
            MoveToPosition(newPos);
        }
    }

    public void ChangeSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }

    public void MoveToPosition(Vector3 newPos)
    {
        StartCoroutine(MoveToPositionCoroutine(newPos));
    }

    private IEnumerator MoveToPositionCoroutine(Vector3 newPos)
    {
        float elapsedTime = 0f;
        float moveDuration = 0.5f;
        Vector3 startingPos = anchor.anchorOffset;

        while (elapsedTime < moveDuration)
        {
            float t = elapsedTime / moveDuration;
            anchor.anchorOffset = Vector3.Lerp(startingPos, newPos, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        anchor.anchorOffset = newPos;
    }
}
