namespace GenerateurDeMotsDePasseConsole;

internal class GenerateurMdp
{
    private List<string> MotDePasseAMixer = new List<string>();
    private Data data = new();

    public void Lancer()
    {
        GenerateurDeMotDePasse(MotDePasseAMixer);
    }

    private void GenerateurDeMotDePasse(List<string> MotDePasseAMixer)
    {
        MotDePasseAMixer.Clear();
        int incrementDivision = 0;
        int saisieNombre = UtilitairesConsole.DemanderNombre(); // Choix nombre utilisateur

        ChoixTypesUtilisateur(saisieNombre, incrementDivision, MotDePasseAMixer);

        int nombreAleatoire = UtilitairesConsole.NombreAleatoire(1, 4);

        SwitchTypeAleatoire(nombreAleatoire, saisieNombre);
        Console.WriteLine();
        MelangerMdp(MotDePasseAMixer);
    }

    private void ChoixTypesUtilisateur(int saisieNombre, int nombreDeChoixUtilisateur, List<string> MotDePasseAMixer)
    {
        bool ajoutMinuscule = false;
        bool ajoutMajuscule = false;
        bool ajoutNombre = false;
        bool ajoutSymbole = false;

        Console.Write("Veuillez 1 si vous voulez des Minuscule : ");
        if ((Console.ReadLine() == "1"))
        {
            ajoutMinuscule = true;
            nombreDeChoixUtilisateur++;
        }
        Console.Write("Veuillez 1 si vous voulez des Majuscule : ");
        if ((Console.ReadLine() == "1"))
        {
            ajoutMajuscule = true;
            nombreDeChoixUtilisateur++;
        }
        Console.Write("Veuillez 1 si vous voulez des Nombre : ");
        if ((Console.ReadLine() == "1"))
        {
            ajoutNombre = true;
            nombreDeChoixUtilisateur++;
        }
        Console.Write("Veuillez 1 si vous voulez des Symbole : ");
        if ((Console.ReadLine() == "1"))
        {
            ajoutSymbole = true;
            nombreDeChoixUtilisateur++;
        }

        if (ajoutMinuscule)
            IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMinuscule, RepartirChoixUtilisateur(saisieNombre, nombreDeChoixUtilisateur)));
        if (ajoutMajuscule)
            IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMajuscule, RepartirChoixUtilisateur(saisieNombre, nombreDeChoixUtilisateur)));
        if (ajoutNombre)
            IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.Nombres, RepartirChoixUtilisateur(saisieNombre, nombreDeChoixUtilisateur)));
        if (ajoutSymbole)
            IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.Symbole, RepartirChoixUtilisateur(saisieNombre, nombreDeChoixUtilisateur)));
    }

    private void SwitchTypeAleatoire(int nombreAleatoire, int saisieNombre)
    {
        switch (nombreAleatoire)
        {
            case 1:
                IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMinuscule, RetournerResteModulo(saisieNombre, 5)));
                break;

            case 2:
                IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMajuscule, RetournerResteModulo(saisieNombre, 5)));
                break;

            case 3:
                IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.Nombres, RetournerResteModulo(saisieNombre, 5)));
                break;

            case 4:
                IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.Symbole, RetournerResteModulo(saisieNombre, 5)));
                break;
        }
    }

    private int RepartirChoixUtilisateur(int nombre, int nombreDeChoixUtilisateur)
    {
        int resultat = nombre / nombreDeChoixUtilisateur;
        return resultat;
    }

    private int RetournerResteModulo(int nombre, int incrementDivision)
    {
        int modulo = (nombre % incrementDivision);
        return modulo;
    }

    private List<string> ElementsAleatoires(List<string> ListAleatoire, int nombreMax)
    {
        List<string> ElementsAleatoires = new List<string>();

        for (int i = 0; i < nombreMax; i++)
        {
            int lettreAleatoire = UtilitairesConsole.NombreAleatoire(0, ListAleatoire.Count());
            ElementsAleatoires.Add(ListAleatoire[lettreAleatoire]);
        }
        return ElementsAleatoires;
    }

    private List<string> IntegrerToutesLesListes(List<string> MotDePasseMixer, List<string> ListAleatoire)
    {
        foreach (string Element in ListAleatoire)
        {
            MotDePasseMixer.Add(Element);
        }
        return MotDePasseMixer;
    }

    private void MelangerMdp(List<string> MotDePasseAMixer)
    {
        IOrderedEnumerable<string> motDePasseMelanger = MotDePasseAMixer.OrderBy(item => Random.Shared.Next());

        foreach (string CaractereMdp in motDePasseMelanger)
        {
            Console.Write(CaractereMdp);
        }
    }
}
