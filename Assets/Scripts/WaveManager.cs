using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro.EditorUtilities;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    public GameObject swarmer1Prefab;
    public GameObject swarmer2Prefab;
    public GameObject swarmer3Prefab;
    public GameObject swarmer4Prefab;
    public GameObject asteroid1SwarmerPrefab;
    public GameObject asteroid2SwarmerPrefab;

    public float internvalship1 = 3.5f;
    public float intervalast1 = 5f;

    public float internvalship2 = 2f;
    public float intervalast2 = 3f;

    public float internvalship3 = 1.5f;
    public float intervalast3 = 1f;

    public float internvalship4 = 0.5f;
    public float intervalast4 = 0.5f;

    public float time = 30f;
    public float done;

    public bool doneF = false;
    public bool done2F = false;
    public bool done3F = false;

    public TMP_Text Level;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(spawnEnemy(internvalship1, swarmer1Prefab));
        StartCoroutine(spawnEnemy(intervalast1, asteroid1SwarmerPrefab));
        StartCoroutine(spawnEnemy(intervalast1, asteroid2SwarmerPrefab));

    }

    // Update is called once per frame
    void Update()
    {
        done = done += Time.deltaTime;
        if (done >= time & doneF == false)
        {
            StopAllCoroutines();
            doneF = true;
            done = 0;

            Level.text = "Lvl 2";
            Debug.Log("Lvl2");
            StartCoroutine(spawnEnemy(internvalship2, swarmer1Prefab));
            StartCoroutine(spawnEnemy(internvalship2, swarmer2Prefab));
            StartCoroutine(spawnEnemy(intervalast2, asteroid1SwarmerPrefab));
            StartCoroutine(spawnEnemy(intervalast2, asteroid2SwarmerPrefab));
            
        }
        if (done >= time & done2F == false)
        {
            StopAllCoroutines();
            done2F = true;
            done = 0;

            Level.text = "Lvl 3";
            Debug.Log("Lvl3");
            StartCoroutine(spawnEnemy(internvalship2, swarmer1Prefab));
            StartCoroutine(spawnEnemy(internvalship2, swarmer2Prefab));
            StartCoroutine(spawnEnemy(internvalship2, swarmer3Prefab));
            StartCoroutine(spawnEnemy(internvalship2, swarmer4Prefab));
            StartCoroutine(spawnEnemy(intervalast2, asteroid1SwarmerPrefab));
            StartCoroutine(spawnEnemy(intervalast2, asteroid2SwarmerPrefab));
        }
        if (done >= time & done3F == false)
        {
            StopAllCoroutines();
            done3F = true;
            done = 0;
            Level.text = "Final";
            Debug.Log("Final lvl");
            StartCoroutine(spawnEnemy(internvalship2, swarmer1Prefab));
            StartCoroutine(spawnEnemy(internvalship2, swarmer2Prefab));
            StartCoroutine(spawnEnemy(internvalship2, swarmer3Prefab));
            StartCoroutine(spawnEnemy(internvalship2, swarmer4Prefab));
            StartCoroutine(spawnEnemy(intervalast2, asteroid1SwarmerPrefab));
            StartCoroutine(spawnEnemy(intervalast2, asteroid2SwarmerPrefab));
        }

        if (done >= time & done3F ==true)
        {
            StopAllCoroutines();
            SceneManager.LoadScene("Win");
        }


    }

   private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(10.95f, Random.Range(-4f, 4f), 0), Quaternion.identity );
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
