using System;

[Serializable]
public class ScryfallPriceObject
{
    public string usd;
    public string eur;
    public DateTime date;
    public SFPricesArrayObject prices;
}

[Serializable]
public class SFPricesArrayObject
{
    public string usd;
    public string usd_foil;
    public string eur;
    public string tix;
}