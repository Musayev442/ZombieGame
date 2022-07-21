using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    //Singleton Instance
    public static WaveManager instance;

    //Enemylerin izleyeceyi obyekt
    [SerializeField] private GameObject targetObject;

    //Enemylerin spawn edeceyi noqteler
    [SerializeField] private Transform[] enemySpawnPoints;

    //enemylerin prefablari
    [SerializeField] private GameObject[] enemyPrefabs;

    //melumat xarakterli text
    [SerializeField] private Text infoText;

    //Object pooling ucun stack
    [SerializeField] private Stack<GameObject> enemyPool=new Stack<GameObject>();

    //her wave ucun saygac rolunu oynayan deyisen
    [SerializeField] private int waveEnemyCount;

    //her wave ucun holder rolunu oynayan deyisen
    [SerializeField] private int waveEnemyCountHolder;

    //waveler arasinda vaxt limiti
    [SerializeField] private int waveStartDel;

    //enemyler arasinda spawn gozleme vaxti
    [SerializeField] private float spawnTimeDel=2f;

    //wavelerin max sayi
    [SerializeField] private int maxNumberOfLevels;

    //hazirki wave-in sayi
    [SerializeField] private int currentNumberOfLevel;


    private void Awake()
    {
        //singletonu teyin edirik.
        instance = this;
    }
    private void Start()
    {
        //Evvelce baslangic enemylerin sayini teyin edirik.
        waveEnemyCount = waveEnemyCountHolder;

        //Wave baslamadan once mueyyen timer baslatmaq lazimdir.
        StartCoroutine(TimeDelay(waveStartDel));

        //Object pool ucun reserve obyektler topluyuruq.
        InvokeRepeating("CheckPool", 0, 0.05f);
    }


    IEnumerator TimeDelay(int waveStDel)
    {
        for(int i = waveStDel; i >0; i--)
        {

            infoText.text = "Wave starts in " + (i - 1).ToString() + " seconds";
            yield return new WaitForSeconds(1f);
        }

        infoText.text = "Wave is coming";

        spawnTimeDel =spawnTimeDel<=0 ? spawnTimeDel- 0.1f: 0.1f;

        StartCoroutine(SpawnEnemyWave(1));

        
    }



    private IEnumerator SpawnEnemyWave(int spawnTimeDelay)
    {
        //Her defe wave basliyanda wave-deki enemylerin sayini random olaraq artiririq.
        waveEnemyCountHolder += Random.Range(5, 10);

        //saygacimizin qiymetini teyin edirik.
        waveEnemyCount = waveEnemyCountHolder;

        //burda ise enemyleri spawn edirik
        for(int i = 0; i < waveEnemyCountHolder; i++)
        {

            //enemy-ni spawn edeceyimiz random noqteni teyin edirik.
            int randomSpawnIndex = Random.Range(0, enemySpawnPoints.Length);

            //enemy-ni pooldan cixaririq.
            GameObject enemy = enemyPool.Pop();

            //Enemy-nin pozisiyasini bizim spawn pointe yerlestiririk.
            enemy.transform.position = enemySpawnPoints[randomSpawnIndex].position;

            //enemyni aktivlesdiririk.
            enemy.SetActive(true);

            //Enemy-e target-e dogru getmsini temin edirik.
            //enemy.GetComponent<EnemyController>().FollowTarget(targetObject.transform);

            yield return new WaitForSeconds(spawnTimeDelay);
        }
    }

    private void CheckPool()
    {
        if((enemyPool.Count<200))
        {
            int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);

            GameObject enemy = Instantiate(enemyPrefabs[randomEnemyIndex]);

            enemy.SetActive(false);

            enemyPool.Push(enemy);
        }
    }

    public void KillEnemy()
    {


        waveEnemyCount--;

        if (waveEnemyCount == 0)
        {
            currentNumberOfLevel++;

            if (currentNumberOfLevel > maxNumberOfLevels)
            {
                Debug.Log("You Win");
                StopAllCoroutines();
                return;
            }

            StartCoroutine(TimeDelay(waveStartDel));
        }


    }
}
