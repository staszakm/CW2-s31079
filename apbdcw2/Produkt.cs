namespace apbdcw2;

public class Produkt
{
    public string nazwa;
    public double temperatura;

    public Produkt(string nazwa, double tempMin)
    {
        this.nazwa = nazwa;
        this.temperatura = tempMin;
    }
}