namespace GenerateurDeMotsDePasseConsole;
internal class GenerateurMdp
{
    public static int _nombreDeCaracteres = 8;

    public static List<string> LettresMiniscule = new List<string>
    {
        "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
        "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
    };

    public static List<string> Nombres = new List<string>
    {
       "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
    };

    public static List<string> LettresAleatoire()
    {
        List<string> lettresAleatoires = new List<string>();

        for (int i = 0; i < _nombreDeCaracteres / 2; i++)
        {
            int lettreAleatoire = Random.Shared.Next(0, LettresMiniscule.Count());
            lettresAleatoires.Add(LettresMiniscule[lettreAleatoire]);
        }
        return lettresAleatoires;
    }

    public static List<string> NombresAleatoire()
    {
        List<string> nombresAleatoires = new List<string>();

        for (int i = 0; i < _nombreDeCaracteres / 2; i++)
        {
            int nombreAleatoire = Random.Shared.Next(0, Nombres.Count());

            nombresAleatoires.Add(Nombres[nombreAleatoire]);
        }

        return nombresAleatoires;
    }

    public static void AgglomererEtMelangerEtAfficherListes()
    {
        List<string> MotDePasseMixer = new List<string>();

        foreach (string lettre in LettresAleatoire())
        {
            MotDePasseMixer.Add(lettre);
        }

        foreach (string nombre in NombresAleatoire())
        {
            MotDePasseMixer.Add(nombre);
        }

        Console.WriteLine("\r\nAvant mélange");
        foreach (string CaractereMdp in MotDePasseMixer)
        {
            Console.Write(CaractereMdp);
        }

        // mixer pour de vrai avant d'afficher
        IOrderedEnumerable<string> toto = MotDePasseMixer.OrderBy(item => Random.Shared.Next());

        Console.WriteLine("\r\nAprès mélange");
        foreach (string CaractereMdp in toto)
        {
            Console.Write(CaractereMdp);
        }

    }

    //public static void AfficherMdp(List<string> MotDePasseMixer)
    //{
    //    foreach (string CaractereMdp in MotDePasseMixer)
    //    {
    //        Console.Write(CaractereMdp);
    //    }
    //}

}
