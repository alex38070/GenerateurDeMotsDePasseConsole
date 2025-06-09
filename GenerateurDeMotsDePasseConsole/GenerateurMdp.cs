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
        int nombre = UtilitairesConsole.MixerChoixUtilisateur();
        Console.WriteLine(nombre);
        AgglomererEtAfficherListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMinuscule, nombre));
        AgglomererEtAfficherListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMajuscule, nombre));
        AgglomererEtAfficherListes(MotDePasseAMixer, ElementsAleatoires(data.Nombres, nombre));
        AgglomererEtAfficherListes(MotDePasseAMixer, ElementsAleatoires(data.Symbole, nombre));
        MixerMdp(MotDePasseAMixer);

    }

    private List<string> AgglomererEtAfficherListes(List<string> MotDePasseMixer, List<string> ListAleatoire)
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

}
