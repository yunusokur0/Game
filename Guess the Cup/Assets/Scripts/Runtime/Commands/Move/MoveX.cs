using UnityEngine;

public class MoveX
{
    private readonly CupsManager _cupsManager;
    private float _speed;
    public MoveX(CupsManager CupsManager, float speed)
    {
        _speed = speed;
        _cupsManager = CupsManager;
    }

    public void Execute(GameObject obj, Vector3 obj2, Vector3 obj3, int carpan, float dis, float sppeed)
    {
        if (!_cupsManager.ReachedTarget)
        {
            _cupsManager.CupMovementTime += Time.deltaTime;
            float t = _cupsManager.CupMovementTime * _speed * sppeed;
            Vector3 newPosition = Vector3.Lerp(obj2, obj3, t);
            newPosition.x += Mathf.Sin(carpan * t * Mathf.PI) * (dis);
            obj.transform.position = newPosition;

            if (t > 1f)
            {
                _cupsManager.ReachedTarget = true;
            }
        }
    }
}