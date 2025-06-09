namespace GenerateurDeMotsDePasseConsole;

public class UtilitairesConsole
{

    public static int DemanderNombre() // Choix nombre utilisateur
    {
        while (true)
        {
            Console.WriteLine("Veuillez saisir un nombre pour la longueur du mot de passe");
            string saisie = Console.ReadLine();
            bool estChiffre = (int.TryParse(saisie, out int nombre));

            if (estChiffre)
                return nombre;
        }
    }

    public static int MixerChoixUtilisateur() // Mixer Nombre utiisateur pour 4 type
    {
        int resultat = DemanderNombre();
        int modulo = (resultat % 4);
        if (modulo == 0)
            return resultat / 4;

        if (modulo == 1)
            return (resultat / 4) + 1;

        if (modulo == 2)
            return (resultat / 4) + 2;

        return 0;
    }
}
