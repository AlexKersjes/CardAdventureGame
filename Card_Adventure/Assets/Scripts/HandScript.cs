using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandScript : MonoBehaviour
{
    public float Margin;
    public float CurveHeight;
    [Range(0,1)]
    public float PercentageFromBottom;
    [Range(0, 1)]
    public float SpacePerCard;
    RectTransform rt;
    [SerializeField]
    GameObject prefab;
    Vector2 parPosition;
    List<pseudoTransform> TargetTransforms;

    public class pseudoTransform { public Vector2 position; public Quaternion rotation; public pseudoTransform(Vector2 position, Quaternion rotation) { this.position = position; this.rotation = rotation; } }

    private void Start()
    {
        TargetTransforms = new List<pseudoTransform>();
        rt = this.GetComponent<RectTransform>();
        parPosition = this.transform.parent.position;
        if (rt == null)
            throw new System.Exception("No recttransform on " + this.name);
        /*for (float i = 0f; i < 1.05f; i+=0.1f)
        {
            new pseudoTransform(HandCurve(i), Quaternion.AngleAxis(-Mathf.Rad2Deg * Mathf.Sin(GetNormalV(i).x), Vector3.forward));
            GameObject g = Instantiate<GameObject>(prefab, this.transform);
            g.transform.position = HandCurve(i);
            g.name = "handPath"+i.ToString();
            g.transform.rotation = Quaternion.AngleAxis(-Mathf.Rad2Deg*Mathf.Sin(GetNormalV(i).x), Vector3.forward);
        }*/
    }

    Vector2 BezierCurve (Vector2 p0, Vector2 p1, Vector2 p2, float t)
    {
        Vector2 x = Lerp(p0, p1, t);
        Vector2 y = Lerp(p1, p2, t);
        return Lerp(x, y, t);
    }
    Vector2 Lerp (Vector2 p0, Vector2 p1, float t)
    {
        return (p1 - p0) * t + p0;
    }
    Vector2 HandCurve(float t)
    {
        Vector2 anchor = new Vector2(parPosition.x,parPosition.y-rt.rect.height*0.5f);
        anchor += new Vector2(0, -0.5f * rt.rect.height + rt.rect.height * PercentageFromBottom);
        Vector2 p0 = new Vector2(anchor.x - 0.5f * rt.rect.width + Margin, anchor.y);
        Vector2 p1 = new Vector2(anchor.x, anchor.y + CurveHeight);
        Vector2 p2 = new Vector2(anchor.x + 0.5f * rt.rect.width - Margin, anchor.y);
        return BezierCurve(p0, p1, p2, t);
    }

    Vector2 GetNormalV(float t)
    {
        Vector2 direction = (HandCurve(t+0.01f) - HandCurve(t)).normalized;
        return new Vector2(-direction.y, direction.x);
    }

    public pseudoTransform AddTransform()
    {
        pseudoTransform target = new pseudoTransform(new Vector2(0, 0), new Quaternion(0, 0, 0, 0));
        TargetTransforms.Insert(0, target );
        UpdateTargetTransforms();
        return TargetTransforms[0];
    }

    private void UpdateTargetTransforms()
    {
        if (SpacePerCard * TargetTransforms.Count > 1)
        {
            float percentPerCard = 1f/(TargetTransforms.Count - 1);
            for (int index = 0; index < TargetTransforms.Count; index++)
            {
                TargetTransforms[index].position = HandCurve(index * percentPerCard);
                TargetTransforms[index].rotation = Quaternion.AngleAxis(-Mathf.Rad2Deg * Mathf.Sin(GetNormalV(index * percentPerCard).x), Vector3.forward);
            }
        }
        else
        {
            float spacetaken = SpacePerCard * (TargetTransforms.Count - 1);
            float spaceleft = (1 - spacetaken) / 2;
            for (int index = 0; index < TargetTransforms.Count; index++)
            {
                TargetTransforms[index].position = HandCurve(index * SpacePerCard + spaceleft);
                TargetTransforms[index].rotation = Quaternion.AngleAxis(-Mathf.Rad2Deg * Mathf.Sin(GetNormalV(index * SpacePerCard + spaceleft).x), Vector3.forward);
            }
        }
    }

    public void RemoveTransform(pseudoTransform t)
    {
        TargetTransforms.Remove(t);
        UpdateTargetTransforms();
    }
}
