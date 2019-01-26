using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClicableMapObject : MonoBehaviour
{
    public Sprite[] sprites;
    private Color color;

    private ClicableMapObjectListener listener;

    public interface ClicableMapObjectListener
    {
        void BuildOnPosition(ClicableMapObject obj);
    }

    public void SetListener(ClicableMapObjectListener listener)
    {
        color = gameObject.GetComponent<SpriteRenderer>().color;
        this.listener = listener;
    }

    private void OnMouseDown()
    {
        color.a = 0;
        gameObject.GetComponent<SpriteRenderer>().color = color;

        listener.BuildOnPosition(this);
        Destroy(gameObject);
    }

    private void OnMouseEnter()
    {
        SetAlpha(1f);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
    }

    private void OnMouseExit()
    {
        SetAlpha(0.22f);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];

    }

    private void SetAlpha(float alpha)
    {
        color.a = alpha;
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }
}
