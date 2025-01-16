using UnityEngine;

public class clickSprite : MonoBehaviour
{
    public Dummy dummy;
    public Sprite newSprite;
    void Start()
    {
        dummy = GameObject.FindGameObjectWithTag("Dummy").GetComponent<Dummy>();
    }

    void OnMouseDown()
    {
        dummy.ChangeSprite(newSprite);
    }
}

