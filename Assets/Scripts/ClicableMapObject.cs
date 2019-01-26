using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClicableMapObject : MonoBehaviour, IPointerClickHandler
{

    void OnClick()
    {
        Debug.Log("CLicked");
    }

    private ClicableMapObjectListener listener;

    public interface ClicableMapObjectListener
    {
        void OnClickPosition(Vector3 position, string tag);

        void OnMouseOverPsition(Vector3 position, string tag);
    }

    public void SetListener(ClicableMapObjectListener listener)
    {
        this.listener = listener;
    }

    private void OnMouseDown()
    {
        listener.OnClickPosition(transform.position, tag);
    }

    private void OnMouseOver()
    {
        listener.OnClickPosition(transform.position, tag);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
