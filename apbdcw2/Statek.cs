namespace apbdcw2;

public class Statek : IHazardNotifier
{
    private double predkosc { get; }
    private int maxLiczbaKontenerow { get; }
    private double maxWagaLadunku { get; }
    private double aktualnaWagaLadunku { get; set; }

    List<Kontener> kontenery;

    private String serial;
    private int serialInteger;
    private static int number = 0;
    int aktualnaLiczbaKontenerow;
    

    public Statek(double predkosc, int maxLiczbaKontenerow, double maxWagaLadunku)
    {
        this.predkosc = predkosc;
        this.maxLiczbaKontenerow = maxLiczbaKontenerow;
        this.maxWagaLadunku = maxWagaLadunku;
        aktualnaWagaLadunku = 0;
        serial = "statek-nr-"+number;
        this.serialInteger = number;
        number++;
        kontenery = new List<Kontener>();
        aktualnaLiczbaKontenerow = 0;
    }

    public void załadujNaStatek(Kontener kontener)
    {
        if ((kontener.getMasaLadunku() + aktualnaWagaLadunku < maxWagaLadunku) && kontener.getCzyNaStatku() == false && aktualnaLiczbaKontenerow < maxLiczbaKontenerow)
        {
            kontenery.Add(kontener);
            aktualnaWagaLadunku += kontener.getMasaLadunku();
            aktualnaLiczbaKontenerow++;
            kontener.setCzyNaStatku(true);
            Console.WriteLine($"Załadowano na statek kontener");
        }
        else
        {
            Notify();
        }
        
    }

    public void załadujListeKontenerow(List<Kontener> konteneryNowe)
    {
        double masa = 0;
        foreach (Kontener k in kontenery)
        {
            masa += k.getMasaLadunku();
        }

        if (masa + aktualnaWagaLadunku < maxWagaLadunku)
        {
            foreach (Kontener k in konteneryNowe)
            {
                kontenery.Add(k);
                aktualnaLiczbaKontenerow++;
                k.setCzyNaStatku(true);
            }
            aktualnaWagaLadunku += masa;
        }
        else
        {
            Notify();
        }
        
    }

    public void usunKontener(Kontener kontener)
    {
        if (kontenery.Contains(kontener))
        {
            aktualnaWagaLadunku -= kontener.getMasaLadunku();
            kontenery.Remove(kontener);
            kontener.setCzyNaStatku(false);
            aktualnaLiczbaKontenerow--;
            
        }
        else
        {
            Console.WriteLine("Ten kontener nie znajduje się na statku");
        }
    }

    public static void przeniesKontener(Kontener kontener, Statek statek1, Statek statek2)
    {
        if (statek1.kontenery.Contains(kontener) && statek2.aktualnaWagaLadunku + kontener.getMasaLadunku() < statek2.maxWagaLadunku && statek2.aktualnaLiczbaKontenerow < statek2.maxLiczbaKontenerow)
        {
            statek1.kontenery.Remove(kontener);
            statek1.aktualnaLiczbaKontenerow--;
            statek1.aktualnaWagaLadunku -= kontener.getMasaLadunku();
            statek2.kontenery.Add(kontener);
            statek2.aktualnaLiczbaKontenerow++;
            statek2.aktualnaWagaLadunku += kontener.getMasaLadunku();
            Console.WriteLine($"Pomyślnie przeniesiono kontener z {statek1.serial} na {statek2.serial}");
        }
        else
        {
            Console.WriteLine($"Przeniesienie kontenera {kontener} ze {statek1} na {statek2} uległo niepowodzeniu");
        }
    }
    
    

    public void Notify()
    {
        Console.WriteLine("Próba niebezpiecznego manewru ze statkiem: "+serial);
    }

    public void printShipInfo()
    {
        Console.WriteLine($"Informacje o statku: {serial}");
        Console.WriteLine($"Prędkość maksymalna: {predkosc} węzłów");
        Console.WriteLine($"Maks. liczba kontenerów: {maxLiczbaKontenerow}");
        Console.WriteLine($"Maks. ładowność: {maxWagaLadunku:N1} ton");
        Console.WriteLine($"Status załadunku:");
        Console.WriteLine($"Załadowane kontenery: {aktualnaLiczbaKontenerow}/{maxLiczbaKontenerow}");
        Console.WriteLine($"Wykorzystana ładowność: {aktualnaWagaLadunku/1000:N1} ton/{maxWagaLadunku:N1} ton");
        foreach (Kontener k in kontenery)
        {
            k.printInfo();
        }
    }

    public String toString()
    {
        return serial;
    }



}