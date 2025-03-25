using System;
using System.Collections.Generic;

namespace apbdcw2;

public class Program
{
    public static void Main(string[] args)
    {
        
        var kontenerL = new KontenerLiq(220, 100, 300, 1000);
        var kontenerG = new KontenerGaz(250, 120, 310, 800, 10);
        var kontenerC = new KontenerChlod(200, 90, 280, 500, -5);

        
        kontenerL.naladuj("chemikalia", 400, true); // niebezpieczny
        kontenerG.naladuj("hel", 200, 5); // gaz
        var produkt = new Produkt("mrożonki", -10);
        kontenerC.naladuj(produkt, 300); // schłodzony
        
        var statek = new Statek(30, 10, 5000);
        
        statek.załadujNaStatek(kontenerL);
        statek.załadujNaStatek(kontenerG);
        
        var listaKontenerow = new List<Kontener> { kontenerC };
        statek.załadujListeKontenerow(listaKontenerow);
        
        statek.usunKontener(kontenerG);
        
        kontenerL.oproznij();
        
        var nowyKontener = new KontenerLiq(220, 100, 300, 1000);
        nowyKontener.naladuj("alkohol", 200, false);
        
        var statek2 = new Statek(25, 10, 3000);
        Statek.przeniesKontener(kontenerC, statek, statek2);
        
        kontenerL.printInfo();
        kontenerG.printInfo();
        kontenerC.printInfo();
        
        statek.printShipInfo();
        statek2.printShipInfo();
    }
}