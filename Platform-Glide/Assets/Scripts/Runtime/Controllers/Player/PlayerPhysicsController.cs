using UnityEngine;
using DG.Tweening;
using TMPro;
using System.Collections;

public class PlayerPhysicsController : MonoBehaviour
{
    public GameObject text1;
    public GameObject cake;
   public Rigidbody rb;
   public Rigidbody rbr;
    public ParticleSystem confeti;

    public GameObject mesh1;
    public GameObject mesh2;

    public PlayerMovementController pmc;
    public bool yes =false;
    public float timer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("green"))
        {
            GameObject spawnedPrefab = Instantiate(text1);
            GameObject levelHolder = GameObject.Find("LevelHolder");

            if (levelHolder != null)
            {
                spawnedPrefab.transform.SetParent(levelHolder.transform);
            }
            spawnedPrefab.transform.position = new Vector3(transform.parent.parent.position.x, transform.parent.parent.position.y - .8f, -3.6f);
            spawnedPrefab.SetActive(true);
            spawnedPrefab.transform.DOScale(new Vector3(1, 1, 1), .6f);
            spawnedPrefab.transform.DOLocalMoveY(spawnedPrefab.transform.position.y + .5f, .4f).OnComplete(() =>
              {
                  spawnedPrefab.transform.DOLocalMoveY(spawnedPrefab.transform.position.y + .29f, .2f);
                  spawnedPrefab.transform.GetComponent<TextMeshPro>().DOColor(Color.green, 0);
              });
        }

        if(other.CompareTag("Finish"))
        {
            Debug.Log("con");
            rbr.isKinematic = true;
            rb.isKinematic = true;
            ParticleSystem part = Instantiate(confeti);
            part.transform.position = other.transform.position;
            part.Play();
            cake.transform.DOScale(new Vector3(.5f,.5f,.5f),.4f);
            cake.transform.DOLocalMoveY(5f, .4f).OnComplete(() =>
            {
                cake.transform.DOScale(new Vector3(0.43f, 0.43f, 0.43f), .8f);
                cake.transform.DOLocalMoveY(1.5f, .85f);
                cake.transform.DORotate(new Vector3(360, 0, 0), 0.7f, RotateMode.FastBeyond360)
                   .SetEase(Ease.Linear);
            });
            pmc.degdi();
            StartCoroutine(sss(other.gameObject));
        }
    }

    private IEnumerator sss(GameObject other)
    {
        yield return new WaitForSeconds(1f);
        rb.isKinematic = false;
        mesh1.SetActive(false);
        mesh2.SetActive(true);
        other.gameObject.SetActive(false);
        cake.SetActive(false);
    }
}