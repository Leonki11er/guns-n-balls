using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    public GameObject Platform;
    public GameObject Crosshair;
    private Vector2 _touchStartPosition,  _touchMovePosition;
    private bool _ppos;
    private float _deltaPos;
    public float XplatformBlock;

    private void Update()
    {
        touchControl();
    }
    private void touchControl()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch theTouch = Input.GetTouch(i);
            MoveCrosshair(theTouch);
            if (theTouch.phase == TouchPhase.Began)
            {
                _touchStartPosition = theTouch.position;
                string startTag = decideWhatIsTouched(_touchStartPosition);
                Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(theTouch.position.x, theTouch.position.y, 0f));
                if (startTag == "Platform")
                {
                    if (pos.x > Platform.transform.position.x)
                    {
                        _ppos = true;
                        _deltaPos = pos.x - Platform.transform.position.x;
                    }
                    else if (pos.x < Platform.transform.position.x)
                    {
                        _ppos = false;
                        _deltaPos = Platform.transform.position.x - pos.x;
                    }
                }
            }
            else if (theTouch.phase == TouchPhase.Moved)
            {
                MoveCrosshair(theTouch);
                _touchMovePosition = theTouch.position;
                Vector3 Current_pos = getTouchPosition(theTouch.position);
                string currentTag = decideWhatIsTouched(_touchMovePosition);
                if (currentTag == "Platform")
                {
                    if (Mathf.Abs(_deltaPos) < 0.1f)
                    {
                        MovePaddleCenter(theTouch);
                    }
                    else
                        MovePlatformBySwipe(theTouch);
                }
            }
            i++;
        }
    }
    private Vector3 getTouchPosition(Vector3 touchPosition)
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, 0));
    }
    private GameObject whatIsTouched(Vector2 touch)
    {
        GameObject obj = null;
        Ray toTouch = Camera.main.ScreenPointToRay(touch);
        RaycastHit rchInfo;
        bool didHit = Physics.Raycast(toTouch, out rchInfo, 50f);
        if (didHit)
        {
            obj = rchInfo.collider.gameObject;
        }
        return obj;
    }
    private void MoveCrosshair(Touch t)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, 0f));
        if (pos.y < -2f) return;
        Crosshair.transform.position = new Vector3(pos.x, pos.y, Crosshair.transform.position.z);
    }
    private void MovePaddleCenter(Touch theTouch)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(theTouch.position.x, 0f, 0f));
        if (pos.x < XplatformBlock && pos.x > -XplatformBlock)
        {
            Platform.transform.position = new Vector3(pos.x, Platform.transform.position.y, Platform.transform.position.z);
        }
    }
    private void MovePlatformBySwipe(Touch t)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, 0f, 0f));
        if (_ppos && pos.x > Platform.transform.position.x && (pos.x - _deltaPos) < XplatformBlock && (pos.x - _deltaPos) > -XplatformBlock)
        {
            Platform.transform.position = new Vector3(pos.x - _deltaPos, Platform.transform.position.y, Platform.transform.position.z);
        }
        if (!_ppos && pos.x < Platform.transform.position.x && (pos.x + _deltaPos) < XplatformBlock && (pos.x + _deltaPos) > -XplatformBlock)
        {
            Platform.transform.position = new Vector3(pos.x + _deltaPos, Platform.transform.position.y, Platform.transform.position.z);
        }
    }
    private string decideWhatIsTouched(Vector2 touch)
    {
        string tag = "null";
        GameObject obj;
        obj = whatIsTouched(touch);
        if (obj)
        {
            tag = obj.tag;
        }else if (!obj)
        {
            tag = "noObject";
        }
        return tag;
    }

















}
