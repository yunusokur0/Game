using UnityEngine;

public class ObjeCountThree : IState
{
    private CupsManager _cupsManager;
    private MoveX _moveX;
    private MoveYX _moveYX;

    public ObjeCountThree(CupsManager CupsManager, MoveX movex, MoveYX moveYX)
    {
        _cupsManager = CupsManager;
        _moveX = movex;
        _moveYX = moveYX;
    }

    public void EnterState()
    {
        for (int i = 0; i < 3; i++)
        {
            int selectedIndex = Random.Range(0, _cupsManager.temporaryCupList.Count);
            GameObject selectedObj = _cupsManager.temporaryCupList[selectedIndex];
            _cupsManager.chosenCupList.Add(selectedObj);
            _cupsManager.cupTransform.Add(selectedObj.transform.position);
            _cupsManager.temporaryCupList.RemoveAt(selectedIndex);
        }

        for (int i = 0; i < 3; i++)
        {
            int nextIndex = (i + 1) % _cupsManager.cupTransform.Count;
            Vector3 diff = _cupsManager.cupTransform[nextIndex] - _cupsManager.cupTransform[i];
            _cupsManager.distance[i] = diff.sqrMagnitude;

            if (_cupsManager.distance[i] >= 10f && _cupsManager.distance[i] <= 15f)
            {
                _cupsManager.distance[i] = 1.5f;
            }
            else
            {
                _cupsManager.distance[i] = 1.04f;
            }
        }
    }

    public void MoveX()
    {
        for (int i = 0; i < 3; i++)
        {
            int nextIndex = (i + 1) % 3;
            _moveX.Execute(_cupsManager.chosenCupList[i], _cupsManager.cupTransform[i], _cupsManager.cupTransform[nextIndex], 1, _cupsManager.distance[i], 1f);
        }
    }

    public void MoveYX()
    {
        for (int i = 0; i < 3; i++)
        {
            int nextIndex = (i + 1) % 3;
            _moveYX.Execute(_cupsManager.chosenCupList[i], _cupsManager.cupTransform[i], _cupsManager.cupTransform[nextIndex], 1, _cupsManager.distance[i], 1);
        }
    }
}