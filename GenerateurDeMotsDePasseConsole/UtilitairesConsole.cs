namespace GenerateurDeMotsDePasseConsole;

public class UtilitairesConsole
{

    public int MixerChoixUtilisateur()
    {
        return DemanderNombre();
    }
    public static int DemanderNombre()
    {
        do
        {
            Console.WriteLine("Veuillez saisir un nombre pour la longueur du mot de passe");
            string saisie = Console.ReadLine();
            bool estChiffre = (int.TryParse(saisie, out int nombre));
            if (estChiffre)
                return nombre;

        } while (true);
    }
}
