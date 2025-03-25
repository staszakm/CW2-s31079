namespace apbdcw2;

public class Kontener
{
    private double masaLadunku;
    double wysokosc {get; set;}
    double masaWlasna {get; set;}
    double glebokosc {get; set;}
    protected double maxLadownosc {get; set;}
    private double masaCalkowita;

    bool czyNaStatku;

    public Kontener(double wysokosc, double masaWlasna, double glebokosc, double maxLadownosc)
    {
        this.wysokosc = wysokosc;
        this.masaWlasna = masaWlasna;
        this.glebokosc = glebokosc;
        this.maxLadownosc = maxLadownosc;
        this.masaLadunku = 0;
        czyNaStatku = false;
    }

    public double getMasaLadunku()
    {
        return this.masaLadunku;
    }
    public void setMasaLadunku(double value)
    {
        this.masaLadunku = value;
    }
    public bool getCzyNaStatku()
    {
        return this.czyNaStatku;
    }
    public void setCzyNaStatku(bool value)
    {
        this.czyNaStatku = value;
    }
    public double getWysokosc()
    {
        return this.wysokosc;
    }
    public double getGlebokosc()
    {
        return this.glebokosc;
    }
    public double getMasaWlasna()
    {
        return this.masaWlasna;
    }

    public void printInfo()
    {
        Console.WriteLine($"Wymiary: {wysokosc}cm (H) x {glebokosc}cm (D)");
        Console.WriteLine($"Masa własna: {masaWlasna} kg");
        Console.WriteLine($"Ładowność: {masaLadunku} kg / {maxLadownosc} kg");
        Console.WriteLine($"Masa całkowita: {masaWlasna + masaLadunku} kg");
        Console.WriteLine($"Status: {(czyNaStatku ? "Załadowany na statek" : "W magazynie")}");
        Console.WriteLine("==========================================\n");
    }
    
    
    
    
    
    
}