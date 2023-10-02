public class Rabatberegner {
    static void Main(string[] args) { }
    public double GetPrisEfterRabat(int antalVarer, double stykPris) {
        double bruttoPris = antalVarer * stykPris;
        if (bruttoPris > 1000 && antalVarer > 10) {
            // Indkøb over 1000 kr. og flere end 10 varer giver 5% rabat
            double rabat = bruttoPris * 0.05;
            bruttoPris -= rabat;
        }
        else if (bruttoPris > 1000) {
            // Indkøb over 1000 kr. giver 3% rabat
            double rabat = bruttoPris * 0.03;
            bruttoPris = bruttoPris - rabat;
        }
        else if (antalVarer > 10) {
            // Flere end 10 varer giver 2% rabat
            double rabat = bruttoPris * 0.02;
            bruttoPris = bruttoPris - rabat;
        }

        return bruttoPris;
    }
} 