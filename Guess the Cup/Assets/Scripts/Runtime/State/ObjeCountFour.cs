using UnityEngine;

public class ObjeCountFour : IState
{
    private CupsManager _cupsManager;
    private MoveX _moveX;

    public ObjeCountFour(CupsManager CupManager, MoveX moveX)
    {
        _cupsManager = CupManager;
        _moveX = moveX;
    }

    public void EnterState()
    {
        foreach (GameObject objet in _cupsManager.cupList)
        {
            _cupsManager.C4pTransform.Add(objet.transform.position);
        }

        for (int i = 0; i < 4; i++)
        {
            int nextIndex = (i + 1) % _cupsManager.C4pTransform.Count;
            Vector3 diff = _cupsManager.C4pTransform[nextIndex] - _cupsManager.C4pTransform[i];
            _cupsManager.distance[i] = diff.sqrMagnitude / 9;
        }
    }

    public void MoveX()
    {
        _moveX.Execute(_cupsManager.cupList[0], _cupsManager.C4pTransform[0], _cupsManager.C4pTransform[1], 1, _cupsManager.distance[0], 1);
        _moveX.Execute(_cupsManager.cupList[1], _cupsManager.C4pTransform[1], _cupsManager.C4pTransform[2], 1, _cupsManager.distance[1], 1);
        _moveX.Execute(_cupsManager.cupList[2], _cupsManager.C4pTransform[2], _cupsManager.C4pTransform[3], 1, _cupsManager.distance[2], 1);
        _moveX.Execute(_cupsManager.cupList[3], _cupsManager.C4pTransform[3], _cupsManager.C4pTransform[0], 1, _cupsManager.distance[3], 1);
    }

    public void MoveYX()
    {
        throw new System.NotImplementedException();
    }
}