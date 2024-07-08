using UnityEngine;

public class ObjeCountTwo : IState
{
    private CupsManager _cupsManager;
    private MoveX _moveX;
    private MoveYX _moveYX;

    public ObjeCountTwo(CupsManager CupsManager, MoveX movex, MoveYX moveYX)
    {
        _cupsManager = CupsManager;
        _moveX = movex;
        _moveYX = moveYX;
    }

    public void EnterState()
    {
        for (int i = 0; i < 2; i++)
        {
            int selectedIndex = Random.Range(0, _cupsManager.temporaryCupList.Count);
            GameObject selectedObj = _cupsManager.temporaryCupList[selectedIndex];
            _cupsManager.chosenCupList.Add(selectedObj);
            _cupsManager.cupTransform.Add(selectedObj.transform.position);
            _cupsManager.temporaryCupList.RemoveAt(selectedIndex);
        }

        for (int i = 0; i < 2; i++)
        {
            int nextIndex = (i + 1) % _cupsManager.cupTransform.Count;
            Vector3 diff = _cupsManager.cupTransform[nextIndex] - _cupsManager.cupTransform[i];
            _cupsManager.distance[i] = diff.sqrMagnitude;

            if (_cupsManager.distance[i] >= 10f && _cupsManager.distance[i] <= 15f)
            {

                _cupsManager.distance[i] = 1.7f;
            }

            else
            {
                _cupsManager.distance[i] = 1.035f;
            }
        }
    }

    public void MoveX()
    {
        _moveX.Execute(_cupsManager.chosenCupList[0], _cupsManager.cupTransform[0], _cupsManager.cupTransform[1], -1, _cupsManager.distance[0], 2f);
        _moveX.Execute(_cupsManager.chosenCupList[1], _cupsManager.cupTransform[1], _cupsManager.cupTransform[0], 1, _cupsManager.distance[1], 2f);
    }

    public void MoveYX()
    {
        _moveYX.Execute(_cupsManager.chosenCupList[0], _cupsManager.cupTransform[0], _cupsManager.cupTransform[1], -1, _cupsManager.distance[0], 2f);
        _moveYX.Execute(_cupsManager.chosenCupList[1], _cupsManager.cupTransform[1], _cupsManager.cupTransform[0], 1, _cupsManager.distance[1], 2f);
    }
}