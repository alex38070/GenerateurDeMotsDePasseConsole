namespace GenerateurDeMotsDePasseConsole;

internal class GenerateurMdp
{
    private List<string> MotDePasseAMixer = new List<string>();

    Data data = new();

    public void Lancer()
    {
        GenerateurDeMotDePasse(MotDePasseAMixer);
    }

    private void GenerateurDeMotDePasse(List<string> MotDePasseAMixer) // 4 et 40
    {
        MotDePasseAMixer.Clear();
        int nombre = UtilitairesConsole.DemanderNombre(); // Choix nombre utilisateur

        IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMinuscule, RepartirChoixUtilisateur(nombre)));
        IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMajuscule, RepartirChoixUtilisateur(nombre)));
        IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.Nombres, RepartirChoixUtilisateur(nombre)));
        IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.Symbole, RepartirChoixUtilisateur(nombre)));

        int nombreAleatoire = UtilitairesConsole.NombreAleatoire(1, 4);
        switch (nombreAleatoire)
        {
            case 1:
                IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMinuscule, Modulo(nombre)));
                break;

            case 2:
                IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMajuscule, Modulo(nombre)));
                break;

            case 3:
                IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.Nombres, Modulo(nombre)));
                break;

            case 4:
                IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.Symbole, Modulo(nombre)));
                break;
        }
        Console.WriteLine();
        MixerMdp(MotDePasseAMixer);
    }

    private int RepartirChoixUtilisateur(int nombre)
    {
        int resultat = nombre / 4;
        return resultat;
    }

    private int Modulo(int nombre)
    {
        int modulo = (nombre % 4);
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

    private void MixerMdp(List<string> MotDePasseAMixer)
    {
        IOrderedEnumerable<string> toto = MotDePasseAMixer.OrderBy(item => Random.Shared.Next());

        foreach (string CaractereMdp in toto)
        {
            Console.Write(CaractereMdp);
        }
    }
}
