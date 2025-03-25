namespace apbdcw2;

public class KontenerGaz : Kontener, IHazardNotifier
{
    private static int serial = 0;
    private String numerSeryjny { get; set; }
    String nazwaLadunku { get; set; }
    double cisnienie { get; set; }
    double aktualneCisnienie { get; set; }
    double maxCisnienie { get; set; }

    String getNumerSeryjny()
    {
        return numerSeryjny;
    }
    
    public KontenerGaz(double wysokosc, double masaWlasna, double glebokosc, double maxLadownosc, double maxCisnienie) 
        :base(wysokosc, masaWlasna, glebokosc, maxLadownosc)
    {
        this.numerSeryjny = "KON-G-"+serial;
        serial++;
        cisnienie = 0;
        this.maxCisnienie = maxCisnienie;
    }

    public void naladuj(String nazwa, double ladunek, double cisnienie)
    {
        try
        {
            if (ladunek + getMasaLadunku() < base.maxLadownosc && aktualneCisnienie + cisnienie < maxCisnienie) 
            {
                setMasaLadunku(getMasaLadunku() + ladunek);
                aktualneCisnienie = cisnienie;
                nazwaLadunku = nazwa;
                Console.WriteLine($"Kontener: {numerSeryjny}, został załadowany towarem: {nazwaLadunku}");
            }
            else
            {
                throw new OverfillException("Zbyt duzy ladunek");
            }
            
        }
        catch (OverfillException e)
        {
            Console.WriteLine(e);
        }

    }

    public void oproznij()
    {
        setMasaLadunku(getMasaLadunku() * 0.05);
        aktualneCisnienie *= aktualneCisnienie*0.5;
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
        Console.WriteLine("=== Kontener gazowy (G) ===");
        Console.WriteLine($"Numer seryjny: {numerSeryjny}");
        Console.WriteLine($"Gaz: {nazwaLadunku}");
        Console.WriteLine($"Ciśnienie: {cisnienie} atm");
        Console.WriteLine($"Masa ładunku: {getMasaLadunku()} kg / {maxLadownosc} kg");
        Console.WriteLine($"Pozostałość po opróżnieniu: {getMasaLadunku() * 0.05} kg");
        Console.WriteLine($"Waga własna: {getMasaWlasna()} kg");
        Console.WriteLine("=================================\n");
    }

    

}