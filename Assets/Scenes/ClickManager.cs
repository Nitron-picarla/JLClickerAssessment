using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClickManager : MonoBehaviour
{
    public static float bigClicksTotal, bigClicksUnspent, CPS;
    public static int workerPurchased, bobcatPurchased, excavatorPurchased, explosivePurchased, BWPurchased, ABPurchased, HBPurchased, OKBPurchased, laserPurchased;
    public float workerCost, bobcatCost, excavatorCost, explosiveCost, BWCost, ABCost, HBCost, OKBCost, laserCost;
    public bool speedUp=false;
    [SerializeField]
    Text CPStext, unspentCounter, totalCounter, TworkerCost, TbobcatCost, TexcavatorCost, TexplosiveCost, TBWCost, TABCost, THBCost, TOKBCost, TlaserCost, TworkerPurchased, TbobcatPurchased, TexcavatorPurchased, TexplosivePurchased, TBWPurchased, TABPurchased, THBPurchased, TOKBPurchased, TlaserPurchased;
    void Start()
    {
        bigClicksUnspent = PlayerPrefs.GetFloat("StoredClicks", 0);
        bigClicksTotal = PlayerPrefs.GetFloat("TotalClicks", 0);

        workerPurchased = PlayerPrefs.GetInt("PurchasedWorkers", 0);
        bobcatPurchased = PlayerPrefs.GetInt("PurchasedBobcats", 0);
        excavatorPurchased = PlayerPrefs.GetInt("PurchasedExcavators", 0);
        explosivePurchased = PlayerPrefs.GetInt("PurchasedCharges", 0);
        BWPurchased = PlayerPrefs.GetInt("PurchasedBWExcavators", 0);
        ABPurchased = PlayerPrefs.GetInt("PurchasedAtomBombs", 0);
        HBPurchased = PlayerPrefs.GetInt("PurchasedHydrogenBombs", 0);
        OKBPurchased = PlayerPrefs.GetInt("PurchasedOKBs", 0);
        laserPurchased = PlayerPrefs.GetInt("PurchasedLasers", 0);

        workerCost = 10 * Mathf.Pow(1.15f, workerPurchased);
        bobcatCost = 100 * Mathf.Pow(1.15f, bobcatPurchased);
        excavatorCost = 1000 * Mathf.Pow(1.15f, excavatorPurchased);
        explosiveCost = 10000 * Mathf.Pow(1.15f, explosivePurchased);
        BWCost = 100000 * Mathf.Pow(1.15f, BWPurchased);
        ABCost = 1000000 * Mathf.Pow(1.15f, ABPurchased);
        HBCost = 10000000 * Mathf.Pow(1.15f, HBPurchased);
        OKBCost = 100000000 * Mathf.Pow(1.15f, OKBPurchased);
        laserCost = 1000000000 * Mathf.Pow(1.15f, laserPurchased);

        unspentCounter.text = "Number of unspent clicks: " + bigClicksUnspent + ".";
        totalCounter.text = "Number of all-time clicks: " + bigClicksTotal + ".";
        CPStext.text = "" + CPS;

        TworkerCost.text = "Purchase for " + workerCost;
        TbobcatCost.text = "Purchase for " + bobcatCost;
        TexcavatorCost.text = "Purchase for " + excavatorCost;
        TexplosiveCost.text = "Purchase for " + explosiveCost;
        TBWCost.text = "Purchase for " + BWCost;
        TABCost.text = "Purchase for " + ABCost;
        THBCost.text = "Purchase for " + HBCost;
        TOKBCost.text = "Purchase for " + OKBCost;
        TlaserCost.text = "Purchase for " + laserCost;

        TworkerPurchased.text = workerPurchased + " owned.";
        TbobcatPurchased.text = bobcatPurchased + " owned.";
        TexcavatorPurchased.text = excavatorPurchased + " owned.";
        TexplosivePurchased.text = excavatorPurchased + " owned.";
        TBWPurchased.text = BWPurchased + " owned.";
        TABPurchased.text = ABPurchased + " owned.";
        THBPurchased.text = HBPurchased + " owned.";
        TOKBPurchased.text = OKBPurchased + " owned.";
        TlaserPurchased.text = laserPurchased + " owned.";
    }
    public void Update()
    {
        int boost;
        if (speedUp)
        {
            boost = 1000;
        }
        else
        {
            boost = 1;
        }
        CPS = boost *((workerPurchased * 0.1f) + (bobcatPurchased * 1) + (excavatorPurchased * 10) + (explosivePurchased * 100) + (BWPurchased * 1000) + (ABPurchased * 10000) + (HBPurchased * 100000) + (OKBPurchased * 1000000) + (laserPurchased * 10000000));
        bigClicksUnspent += CPS * Time.deltaTime;
        bigClicksTotal += CPS * Time.deltaTime;
        unspentCounter.text = "Number of unspent clicks: " + bigClicksUnspent + ".";
        totalCounter.text = "Number of all-time clicks: " + bigClicksTotal + ".";
        CPStext.text = "" + CPS + " clicks per second.";
    }
    public void Boost()
    {
        speedUp = !speedUp;
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("TotalClicks", bigClicksTotal);
        PlayerPrefs.SetFloat("StoredClicks", bigClicksUnspent);
        PlayerPrefs.SetInt("PurchasedWorkers", workerPurchased);
        PlayerPrefs.SetInt("PurchasedBobcats", bobcatPurchased);
        PlayerPrefs.SetInt("PurchasedExcavators", excavatorPurchased);
        PlayerPrefs.SetInt("PurchasedExplosive", explosivePurchased);
        PlayerPrefs.SetInt("PurchasedBWExcavators", BWPurchased);
        PlayerPrefs.SetInt("PurchasedAtomBombs", ABPurchased);
        PlayerPrefs.SetInt("PurchasedHydrogenBombs", HBPurchased);
        PlayerPrefs.SetInt("PurchasedOKBs", OKBPurchased);
        PlayerPrefs.SetInt("PurchasedLasers", laserPurchased);
    }
    public void Exit()
    {
        PlayerPrefs.SetFloat("TotalClicks", bigClicksTotal);
        PlayerPrefs.SetFloat("StoredClicks", bigClicksUnspent);
        PlayerPrefs.SetInt("PurchasedWorkers", workerPurchased);
        PlayerPrefs.SetInt("PurchasedBobcats", bobcatPurchased);
        PlayerPrefs.SetInt("PurchasedExcavators", excavatorPurchased);
        PlayerPrefs.SetInt("PurchasedExplosive", explosivePurchased);
        PlayerPrefs.SetInt("PurchasedBWExcavators", BWPurchased);
        PlayerPrefs.SetInt("PurchasedAtomBombs", ABPurchased);
        PlayerPrefs.SetInt("PurchasedHydrogenBombs", HBPurchased);
        PlayerPrefs.SetInt("PurchasedOKBs", OKBPurchased);
        PlayerPrefs.SetInt("PurchasedLasers", laserPurchased);
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public void ResetSave()
    {
        PlayerPrefs.SetFloat("TotalClicks", 0);
        PlayerPrefs.SetFloat("StoredClicks", 0);
        PlayerPrefs.SetInt("PurchasedWorkers", 0);
        PlayerPrefs.SetInt("PurchasedBobcats", 0);
        PlayerPrefs.SetInt("PurchasedExcavators", 0);
        PlayerPrefs.SetInt("PurchasedExplosive", 0);
        PlayerPrefs.SetInt("PurchasedBWExcavators", 0);
        PlayerPrefs.SetInt("PurchasedAtomBombs", 0);
        PlayerPrefs.SetInt("PurchasedHydrogenBombs", 0);
        PlayerPrefs.SetInt("PurchasedOKBs", 0);
        PlayerPrefs.SetInt("PurchasedLasers", 0);

        bigClicksUnspent = PlayerPrefs.GetFloat("StoredClicks", 0);
        bigClicksTotal = PlayerPrefs.GetFloat("TotalClicks", 0);

        workerPurchased = PlayerPrefs.GetInt("PurchasedWorkers", 0);
        bobcatPurchased = PlayerPrefs.GetInt("PurchasedBobcats", 0);
        excavatorPurchased = PlayerPrefs.GetInt("PurchasedExcavators", 0);
        explosivePurchased = PlayerPrefs.GetInt("PurchasedCharges", 0);
        BWPurchased = PlayerPrefs.GetInt("PurchasedBWExcavators", 0);
        ABPurchased = PlayerPrefs.GetInt("PurchasedAtomBombs", 0);
        HBPurchased = PlayerPrefs.GetInt("PurchasedHydrogenBombs", 0);
        OKBPurchased = PlayerPrefs.GetInt("PurchasedOKBs", 0);
        laserPurchased = PlayerPrefs.GetInt("PurchasedLasers", 0);

        workerCost = 10 * Mathf.Pow(1.15f, workerPurchased);
        bobcatCost = 100 * Mathf.Pow(1.15f, bobcatPurchased);
        excavatorCost = 1000 * Mathf.Pow(1.15f, excavatorPurchased);
        explosiveCost = 10000 * Mathf.Pow(1.15f, explosivePurchased);
        BWCost = 100000 * Mathf.Pow(1.15f, BWPurchased);
        ABCost = 1000000 * Mathf.Pow(1.15f, ABPurchased);
        HBCost = 10000000 * Mathf.Pow(1.15f, HBPurchased);
        OKBCost = 100000000 * Mathf.Pow(1.15f, OKBPurchased);
        laserCost = 1000000000 * Mathf.Pow(1.15f, laserPurchased);

        CPS = (workerPurchased * 0.1f) + (bobcatPurchased * 1) + (excavatorPurchased * 10) + (explosivePurchased * 100) + (BWPurchased * 1000) + (ABPurchased * 10000) + (HBPurchased * 100000) + (OKBPurchased * 1000000) + (laserPurchased * 10000000);

        unspentCounter.text = "Number of unspent clicks: " + bigClicksUnspent + ".";
        totalCounter.text = "Number of all-time clicks: " + bigClicksTotal + ".";
        CPStext.text = "" + CPS;

        TworkerCost.text = "Purchase for " + workerCost;
        TbobcatCost.text = "Purchase for " + bobcatCost;
        TexcavatorCost.text = "Purchase for " + excavatorCost;
        TexplosiveCost.text = "Purchase for " + explosiveCost;
        TBWCost.text = "Purchase for " + BWCost;
        TABCost.text = "Purchase for " + ABCost;
        THBCost.text = "Purchase for " + HBCost;
        TOKBCost.text = "Purchase for " + OKBCost;
        TlaserCost.text = "Purchase for " + laserCost;

        TworkerPurchased.text = workerPurchased + " owned.";
        TbobcatPurchased.text = bobcatPurchased + " owned.";
        TexcavatorPurchased.text = excavatorPurchased + " owned.";
        TexplosivePurchased.text = excavatorPurchased + " owned.";
        TBWPurchased.text = BWPurchased + " owned.";
        TABPurchased.text = ABPurchased + " owned.";
        THBPurchased.text = HBPurchased + " owned.";
        TOKBPurchased.text = OKBPurchased + " owned.";
        TlaserPurchased.text = laserPurchased + " owned.";
    }
    public void CookieClick()
    {
        bigClicksTotal += 1;
        bigClicksUnspent += 1;
        Debug.Log("Clicked. Now Stored: " + bigClicksUnspent + ". All time: " + bigClicksTotal + ".");
        unspentCounter.text = "Number of unspent clicks: " + bigClicksUnspent + ".";
        totalCounter.text = "Number of all-time clicks: " + bigClicksTotal + ".";

        PlayerPrefs.SetFloat("TotalClicks", bigClicksTotal);
        PlayerPrefs.SetFloat("StoredClicks", bigClicksUnspent);
    }
        public void Worker1()
    {
        if (bigClicksUnspent >= workerCost)
        {
            workerPurchased++;
            bigClicksUnspent -= workerCost;
        }
        PlayerPrefs.SetInt("PurchasedWorkers", workerPurchased);
        workerCost = 10 * Mathf.Pow(1.15f, workerPurchased);
        TworkerCost.text = "Purchase for " + workerCost;
        TworkerPurchased.text = workerPurchased + " owned.";

    }
    public void Bobcat2()
    {
        if (bigClicksUnspent >= bobcatCost)
        {
            bobcatPurchased++;
            bigClicksUnspent -= bobcatCost;
        }
        PlayerPrefs.SetInt("PurchasedBobcats", bobcatPurchased);
        bobcatCost = 100 * Mathf.Pow(1.15f, bobcatPurchased);
        TbobcatCost.text = "Purchase for " + bobcatCost;
        TbobcatPurchased.text = bobcatPurchased + " owned.";
    }
    public void Excavator3()
    {
        if (bigClicksUnspent >= excavatorCost)
        {
            excavatorPurchased++;
            bigClicksUnspent -= excavatorCost;
        }
        PlayerPrefs.SetInt("PurchasedExcavators", excavatorPurchased);
        excavatorCost = 1000 * Mathf.Pow(1.15f, excavatorPurchased);
        TexcavatorCost.text = "Purchase for " + excavatorCost;
        TexcavatorPurchased.text = excavatorPurchased + " owned.";
    }
    public void Explosives4()
    {
        if (bigClicksUnspent >= explosiveCost)
        {
            explosivePurchased++;
            bigClicksUnspent -= explosiveCost;
        }
        PlayerPrefs.SetInt("PurchasedExplosive", explosivePurchased);
        explosiveCost = 10000 * Mathf.Pow(1.15f, explosivePurchased);
        TexplosiveCost.text = "Purchase for " + explosiveCost;
        TexplosivePurchased.text = explosivePurchased + " owned.";        
    }
    public void BucketWheel5()
    {
        if (bigClicksUnspent >= BWCost)
        {
            BWPurchased++;
            bigClicksUnspent -= BWCost;
        }
        PlayerPrefs.SetInt("PurchasedBWExcavators", BWPurchased);
        BWCost = 100000 * Mathf.Pow(1.15f, BWPurchased);
        TBWCost.text = "Purchase for " + BWCost;
        TBWPurchased.text = BWPurchased + " owned.";        
    }
    public void ABomb6()
    {
        if (bigClicksUnspent >= ABCost)
        {
            ABPurchased++;
            bigClicksUnspent -= ABCost;
        }
        PlayerPrefs.SetInt("PurchasedAtomBombs", ABPurchased);
        ABCost = 1000000 * Mathf.Pow(1.15f, ABPurchased);
        TABCost.text = "Purchase for " + ABCost;
        TABPurchased.text = ABPurchased + " owned.";        
    }
    public void Hbomb7()
    {
        if (bigClicksUnspent >= HBCost)
        {
            HBPurchased++;
            bigClicksUnspent -= HBCost;
        }
        PlayerPrefs.SetInt("PurchasedHydrogenBombs", HBPurchased);
        HBCost = 10000000 * Mathf.Pow(1.15f, HBPurchased);
        THBCost.text = "Purchase for " + HBCost;
        THBPurchased.text = HBPurchased + " owned.";        
    }
    public void OKB8()
    {
        if (bigClicksUnspent >= OKBCost)
        {
            OKBPurchased++;
            bigClicksUnspent -= OKBCost;
        }
        PlayerPrefs.SetInt("PurchasedOKBs", OKBPurchased);
        OKBCost = 100000000 * Mathf.Pow(1.15f, OKBPurchased);
        TOKBCost.text = "Purchase for " + OKBCost;
        TOKBPurchased.text = OKBPurchased + " owned.";
    }
    public void Laser9()
    {
        if (bigClicksUnspent >= laserCost)
        {
            laserPurchased++;
            bigClicksUnspent -= laserCost;
        }
        PlayerPrefs.SetInt("PurchasedLasers", laserPurchased);
        laserCost = 1000000000 * Mathf.Pow(1.15f, laserPurchased);
        TlaserCost.text = "Purchase for " + laserCost;
        TlaserPurchased.text = laserPurchased + " owned.";
    }
}
