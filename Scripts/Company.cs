using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Company
{
    public string GetSavePath()
    {
        return System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) // %appdata% folder
            + "/ApocalypseLTD/"
            + m_companyAbr + "_" + m_companyName;
    }

    public static string GetSavePath(string companyName, string companyAbr)
    {
        return System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) // %appdata% folder
            + "/ApocalypseLTD/"
            + companyAbr + "_" + companyName;
    }

    public static Company LoadData(string companyName, string companyAbr)
    {
        Company com = new Company();
        int lines = 0;
        string path = GetSavePath(companyName, companyAbr);
        if(File.Exists(path + "_json.xml")) // checking if company profile exists
        {
            com = JsonUtility.FromJson<Company>(File.ReadAllText(path + "_json.xml"));
            // reading the whole company profile and deserealizing it
        }
        else
        {
            Debug.LogError(companyAbr + "_" + companyName + " Company profile could not be found"); //  yro'ue fucked
        }
        if (File.Exists(path)) // making sure this fucking piece of shit exists
        {
            BinaryReader br = new BinaryReader(new StreamReader(path).BaseStream);
            lines = br.ReadInt32();
            for (int line = 0; line < lines; line++)
            {
                com.priceHistory.Add(br.ReadSingle()); // apparently in the world of C# a float is actually called a single
                // just like me, anyways this shit reads the float and appends it to the price history
            }
        }
        else
        {
            Debug.LogError(companyAbr + "_" + companyName + " History save file could not be found"); //  also fucked
        }
        return com;
    }

    public void SaveData()
    {
        string path = GetSavePath();
        if(File.Exists(path)) File.Delete(path); // deleting the old price history
        BinaryWriter sw = new BinaryWriter(new StreamWriter(path).BaseStream); // creating a binary writer to save space instead of characters
        sw.Write((System.Int32)priceHistory.Count); // write the first element as the number of datapoints stored as 4 bytes just to make sure
        for (int line = 0; line < priceHistory.Count; line++) // writing new price history
        {
            sw.Write(priceHistory[line]); // write raw bytes to file
        }
        sw.Close(); // closing the stream so that windows doesn't fucking piss itself

        string json = JsonUtility.ToJson(this);
        if(File.Exists(path + "_json.xml")) File.Delete(path + "_json.xml"); // deleting the old company profile
        StreamWriter jw = new StreamWriter(path + "_json.xml"); // create a file and open a writer
        jw.Write(json); // write the whole serialized profile to the file
        jw.Close(); // close the profile file writer
    }
    /// <summary> Creates a company from scratch with a blank price history </summary>
    public Company(float volatility, int maxTradingVolume, string companyName, string companyAbr, int companyID, int marketCap, int outstandingShares)
    {
        m_volatility = volatility;
        m_maxTradingVolume = maxTradingVolume;
        m_companyName = companyName;
        m_companyAbr = companyAbr;
        m_companyID = companyID;
        m_marketCap = marketCap;
        m_outstandingShares = outstandingShares;
    }

    public Company()
    {

    }

    private float m_volatility;
    private int m_maxTradingVolume;
    private string m_companyName;
    private string m_companyAbr;
    private int m_companyID;
    private int m_marketCap;
    private int m_outstandingShares;

    /// <summary> Adjusts the price of the company </summary>
    public void ReevaluateCompany(int marketCap)
    {
        m_marketCap = marketCap;
    }

    /// <summary> Calculates the value of selling stocks </summary>
    public float CalculateStockSales(int saleVolume)
    {
        float sum = 0.0f;
        for(int sale = 0; sale < saleVolume; sale++)
        {
            sum += m_marketCap / (m_outstandingShares + sale);
        }
        return sum;
    }

    /// <summary> Calculates the value of purchasing stocks </summary>
    public float CalculateStockPurchase(int purchaseVolume)
    {
        float sum = 0.0f;
        for(int purchase = 0; purchase < purchaseVolume; purchase++)
        {
            sum += m_marketCap / (m_outstandingShares - purchase);
        }
        return sum;
    }

    /// <summary> Purchases stocks from the company </summary>
    public void PurchaseStock(int purchaseVolume)
    {
        m_outstandingShares -= purchaseVolume;
    }

    /// <summary> Sells stocks back to the company </summary>
    public void SellStock(int purchaseVolume)
    {
        m_outstandingShares += purchaseVolume;
    }

    public void SetVolatility(float volatility) { m_volatility = volatility; }

    public int GetShares() { return m_outstandingShares; }
    public string GetName() { return m_companyName; }
    public string GetAbr() { return m_companyAbr; }
    public float GetVolatility() { return m_volatility; }
    public int GetMarketCap() { return m_marketCap; }
    public int GetMaxTradingVolume() { return m_maxTradingVolume; }
    public int GetCompanyID() { return m_companyID; }

    [System.NonSerialized]
    public List<float> priceHistory;
}