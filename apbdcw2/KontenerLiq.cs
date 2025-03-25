namespace apbdcw2;

public class KontenerLiq : Kontener, IHazardNotifier
{
    private static int serial = 0;
    private String numerSeryjny { get; set; }
    String nazwaLadunku { get; set; }

    String getNumerSeryjny()
    {
        return numerSeryjny;
    }
    
    public KontenerLiq(double wysokosc, double masaWlasna, double glebokosc, double maxLadownosc) 
        :base(wysokosc, masaWlasna, glebokosc, maxLadownosc)
    {
        this.numerSeryjny = "KON-L-"+serial;
        serial++;
    }

    public void naladuj(String nazwa, double ladunek, bool niebezpieczny)
    {
        try
        {
            if (ladunek + getMasaLadunku() > base.maxLadownosc)
            {
                throw new OverfillException("Zbyt duzy ladunek");
            }
            if (niebezpieczny)
            {
                if (ladunek + getMasaLadunku() > base.maxLadownosc * 0.5)
                {
                    Notify();
                }
                else
                {
                    setMasaLadunku(getMasaLadunku() + ladunek);
                    nazwaLadunku = nazwa;
                    Console.WriteLine("Kontener: "+numerSeryjny+", został załadowany towarem: "+nazwaLadunku);
                }
            }
            else
            {
                if (ladunek + getMasaLadunku() > base.maxLadownosc * 0.9)
                {
                    Notify();
                }
                else
                {
                    setMasaLadunku(getMasaLadunku() + ladunek);
                    nazwaLadunku = nazwa;
                    Console.WriteLine("Kontener: "+numerSeryjny+", został załadowany towarem: "+nazwaLadunku);
                }
            }
        }
        catch (OverfillException e)
        {
            Console.WriteLine(e);
        }

    }

    public void oproznij()
    {
        setMasaLadunku(0);
        Console.WriteLine("Oprozniono kontener: "+numerSeryjny);
    }

    public void Notify()
    {
        Console.WriteLine("Proba podjecia niebezpiecznego dzialania z kontenerem: "+numerSeryjny);
    }

    public String toString()
    {
        return numerSeryjny;
    }

    public void printInfo()
    {
        Console.WriteLine("=== Kontener na płyny (L) ===");
        Console.WriteLine($"Numer seryjny: {numerSeryjny}");
        Console.WriteLine($"Ładunek: {nazwaLadunku}");
        Console.WriteLine($"Masa ładunku: {getMasaLadunku()} kg / {maxLadownosc} kg");
        Console.WriteLine($"Wysokość: {getWysokosc()} cm");
        Console.WriteLine($"Głębokość: {getGlebokosc()} cm");
        Console.WriteLine($"Waga własna: {getMasaWlasna()} kg");
        Console.WriteLine("=================================\n");
    }

    
}