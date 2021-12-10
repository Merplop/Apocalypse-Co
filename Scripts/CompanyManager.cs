using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CompanyManager
{
    public static List<Company> Companies;
    public static void UpdateCompanies()
    {
        for(int id = 0; id < Companies.Count; id++)
        {
            float decision_weight = UnityEngine.Random.Range(-1.0f, 1.0f);
            int stockPurchase = Mathf.RoundToInt(decision_weight * Companies[id].GetVolatility());
            int mtv = Companies[id].GetMaxTradingVolume();
            stockPurchase = Math.Clamp(stockPurchase, -mtv, mtv);
            Companies[id].PurchaseStock(stockPurchase);
        }
    }
}
