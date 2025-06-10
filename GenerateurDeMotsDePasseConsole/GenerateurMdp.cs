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

        IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMinuscule, MixerChoixUtilisateur(nombre)));
        IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMajuscule, MixerChoixUtilisateur(nombre)));
        IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.Nombres, MixerChoixUtilisateur(nombre)));
        IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.Symbole, MixerChoixUtilisateur(nombre)));

        int nombreAleatoire = UtilitairesConsole.NombreAleatoire();

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
        MixerMdp(MotDePasseAMixer);
    }

    private int MixerChoixUtilisateur(int nombre)
    {
        int resultat = nombre / 4;
        return resultat;
    }

    private int Modulo(int nombre)
    {
        int modulo = (nombre % 4);
        return modulo;
    }

    private List<string> ElementsAleatoires(List<string> ListAleatoire, int nombre)
    {
        List<string> ElementsAleatoires = new List<string>();

        for (int i = 0; i < nombre; i++)
        {
            int lettreAleatoire = Random.Shared.Next(0, ListAleatoire.Count());
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
