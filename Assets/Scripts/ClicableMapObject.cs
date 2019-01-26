using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicableMapObject : MonoBehaviour {

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
}
