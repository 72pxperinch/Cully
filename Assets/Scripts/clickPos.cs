using UnityEngine;

public class clickPos : MonoBehaviour
{
    public Dummy dummy;
    public Vector3 newPosi;
    void Start()
    {
        dummy = GameObject.FindGameObjectWithTag("Dummy").GetComponent<Dummy>();
    }

    void OnMouseDown()
    {
        dummy.MoveToPosition(newPosi);
    }
}

