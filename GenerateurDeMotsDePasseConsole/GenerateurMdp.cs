namespace GenerateurDeMotsDePasseConsole;

internal class GenerateurMdp
{
    private static int _nombreDeCaracteres = 8;

    private static List<string> MotDePasseAMixer = new List<string>();

    Data data = new();

    public void Lancer()
    {
        GenerateurDeMotDePasse(MotDePasseAMixer);
    }

    private void GenerateurDeMotDePasse(List<string> MotDePasseAMixer)
    {
        MotDePasseAMixer.Clear();
        int nombre = UtilitairesConsole.DemanderNombre(); // retourne nombre utilisateur
        IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMinuscule, MixerChoixUtilisateur(nombre))); // le 4  pourrait etre l   list.count
        IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMajuscule, MixerChoixUtilisateur(nombre)));
        IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.Nombres, MixerChoixUtilisateur(nombre)));
        IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.Symbole, MixerChoixUtilisateur(nombre)));

        IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.Nombres, Modulo(nombre))); // ajout si modulo n'est pas zero et pourrais etre choisie au hazar  :
                                                                                                     // - list ou enub
                                                                                                     // - else if nombre aleartoire entre 1 et 4 random (1, 4) puis je change le parammetre pour la list en automatique

        MixerMdp(MotDePasseAMixer);
    }

    public static int MixerChoixUtilisateur(int nombre) // Mixer Nombre utiisateur pour 4 type
    {
        int resultat = nombre / 4; // le 4 pourrait etre l   list.count
        return resultat;
    }

    public static int Modulo(int nombre)
    {
        int modulo = (nombre % 4); // le 4 pourrait etre l   list.count
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

        Console.WriteLine("\r\nAprès mélange");
        foreach (string CaractereMdp in toto)
        {
            Console.Write(CaractereMdp);
        }
    }
}
