namespace apbdcw2;

public class KontenerChlod : Kontener, IHazardNotifier
{
    private static int serial = 0;
    private String numerSeryjny { get; set; }
    String nazwaLadunku { get; set; }
    double temperaturaKontenera { get; set; }

    String getNumerSeryjny()
    {
        return numerSeryjny;
    }
    
    public KontenerChlod(double wysokosc, double masaWlasna, double glebokosc, double maxLadownosc, double temp) 
        :base(wysokosc, masaWlasna, glebokosc, maxLadownosc)
    {
        this.numerSeryjny = "KON-C-"+serial;
        serial++;
        nazwaLadunku = "pusty";
        temperaturaKontenera = temp;
    }

    public void naladuj(Produkt produkt, double ladunek)
    {
        try
        {
            if (ladunek + getMasaLadunku() > base.maxLadownosc)
            {
                throw new OverfillException("Zbyt duzy ladunek");
            }

            if (nazwaLadunku.Equals("pusty"))
            {
                if (temperaturaKontenera >= produkt.temperatura)
                {
                    nazwaLadunku = produkt.nazwa;
                    setMasaLadunku(getMasaLadunku() + ladunek);
                    Console.WriteLine($"Naładowano kontener {serial} produktem {produkt.nazwa}");
                }
                else
                {
                    Notify();
                }
                    
            }
            else
            {
                if (nazwaLadunku.Equals(produkt.nazwa))
                {
                    setMasaLadunku(getMasaLadunku() +ladunek);
                    Console.WriteLine("Doładowano kontener");
                }
                else
                {
                    Notify();
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
        nazwaLadunku = "pusty";
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
        Console.WriteLine("=== Kontener chłodniczy (C) ===");
        Console.WriteLine($"Numer seryjny: {numerSeryjny}");
        Console.WriteLine($"Produkt: {nazwaLadunku}");
        Console.WriteLine($"Temperatura: {temperaturaKontenera}°C");
        Console.WriteLine($"Masa ładunku: {getMasaLadunku()} kg / {maxLadownosc} kg");
        Console.WriteLine($"Wymiary: {getWysokosc()}x{getGlebokosc()} cm");
        Console.WriteLine($"Waga własna: {getMasaWlasna()} kg");
        Console.WriteLine("Zakaz mieszania produktów różnych typów");
        Console.WriteLine("=================================\n");
    }


}