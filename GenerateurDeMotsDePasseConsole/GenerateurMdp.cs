namespace GenerateurDeMotsDePasseConsole;

internal class GenerateurMdp
{
    private List<string> MotDePasseAMixer = new List<string>();
    private Data data = new();

    int nombreDeChoixUtilisateur = 0; // besoin pour la methode modulo
    bool ajoutMinuscule = false;
    bool ajoutMajuscule = false;
    bool ajoutNombre = false;
    bool ajoutSymbole = false;
    string choixUtilisateur;

    public void Lancer()
    {
        GenerateurDeMotDePasse(MotDePasseAMixer);
    }

    private void GenerateurDeMotDePasse(List<string> MotDePasseAMixer)
    {

        do
        {
            ajoutMinuscule = false;
            ajoutMajuscule = false;
            ajoutNombre = false;
            ajoutSymbole = false;

            bool estVraie = false;
            bool nouvelleSaisie = false;
            MotDePasseAMixer.Clear();
            MotDePasseAMixer.Clear();
            int saisieNombre = UtilitairesConsole.DemanderNombre(4, 40); // Choix nombre utilisateur
            int nombreAleatoire = UtilitairesConsole.NombreAleatoire(1, 4); // Choix nombre aleatoire

            ChoixTypesUtilisateur(saisieNombre, MotDePasseAMixer, nombreAleatoire);

            MixerList(nombreAleatoire, saisieNombre);

            Console.WriteLine();
            MelangerMdp(MotDePasseAMixer);

            do
            {
                Console.WriteLine();
                Console.WriteLine("\r\nSouhaitez-vous générer un nouveau mot de passe ?\r\n");
                Console.WriteLine("1. Oui, avec les mêmes critères");
                Console.WriteLine("2. Oui, avec de nouveaux critères");
                Console.WriteLine("3. Non, quitter l'application");

                Console.Write("\r\nChoix : ");
                choixUtilisateur = UtilitairesConsole.DemanderString();

                if (choixUtilisateur == "1")
                {
                    MotDePasseAMixer.Clear();
                    MixerList(nombreAleatoire, saisieNombre);
                    MelangerMdp(MotDePasseAMixer);
                }

            } while (choixUtilisateur == "1");

        } while (choixUtilisateur == "2");
        //Environment.Exit(0);
        Console.WriteLine("Merci au revoir");
    }
    private void ChoixTypesUtilisateur(int saisieNombre, List<string> MotDePasseAMixer, int nombreAleatoire)
    {
        bool choixVide = true;
        do
        {
            nombreDeChoixUtilisateur = 0; // besoin pour la methode modulo
            Console.Write("\r\nVeuillez o/n si vous voulez des Minuscule : ");
            if ((Console.ReadLine() == "o"))
            {
                ajoutMinuscule = true;
                nombreDeChoixUtilisateur++;
            }
            Console.Write("Veuillez o/n si vous voulez des Majuscule : ");
            if ((Console.ReadLine() == "o"))
            {
                ajoutMajuscule = true;
                nombreDeChoixUtilisateur++;
            }
            Console.Write("Veuillez o/n si vous voulez des Nombre : ");
            if ((Console.ReadLine() == "o"))
            {
                ajoutNombre = true;
                nombreDeChoixUtilisateur++;
            }
            Console.Write("Veuillez o/n si vous voulez des Symbole : ");
            if ((Console.ReadLine() == "o"))
            {
                ajoutSymbole = true;
                nombreDeChoixUtilisateur++;
            }
            choixVide = false;

            if (nombreDeChoixUtilisateur == 0)
            {
                choixVide = true;
                Console.WriteLine("\r\nVeuillez faire au moins un choix : ");
            }

        } while (choixVide);
    }

    public void MixerList(int nombreAleatoire, int saisieNombre)
    {
        if (ajoutMinuscule)
            IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMinuscule, RepartirChoixUtilisateur(saisieNombre, nombreDeChoixUtilisateur)));
        if (ajoutMajuscule)
            IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMajuscule, RepartirChoixUtilisateur(saisieNombre, nombreDeChoixUtilisateur)));
        if (ajoutNombre)
            IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.Nombres, RepartirChoixUtilisateur(saisieNombre, nombreDeChoixUtilisateur)));
        if (ajoutSymbole)
            IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.Symbole, RepartirChoixUtilisateur(saisieNombre, nombreDeChoixUtilisateur)));

        switch (nombreAleatoire)
        {
            case 1:
                IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMinuscule, RetournerResteModulo(saisieNombre, nombreDeChoixUtilisateur)));
                break;

            case 2:
                IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMajuscule, RetournerResteModulo(saisieNombre, nombreDeChoixUtilisateur)));
                break;

            case 3:
                IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.Nombres, RetournerResteModulo(saisieNombre, nombreDeChoixUtilisateur)));
                break;

            case 4:
                IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.Symbole, RetournerResteModulo(saisieNombre, nombreDeChoixUtilisateur)));
                break;
        }
    }

    private int RepartirChoixUtilisateur(int nombre, int nombreDeChoixUtilisateur)
    {
        int resultat = 1;
        if (nombreDeChoixUtilisateur != 0)
        {
            resultat = nombre / nombreDeChoixUtilisateur;
            return resultat;
        }
        return resultat;
    }

    private int RetournerResteModulo(int nombre, int nombreDeChoixUtilisateur)
    {
        int modulo = (nombre % nombreDeChoixUtilisateur);
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
            MotDePasseAMixer.Clear();

        }
    }
}
