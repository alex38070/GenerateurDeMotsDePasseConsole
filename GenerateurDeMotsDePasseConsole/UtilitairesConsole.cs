namespace GenerateurDeMotsDePasseConsole;

public class UtilitairesConsole
{

    public static int DemanderNombre(int min, int max) // Choix nombre utilisateur
    {
        while (true)
        {
            Console.Write("Veuillez saisir un nombre entre 4 et 40 de longueur de mot de passe : ");
            string saisie = Console.ReadLine() ?? string.Empty;

            if ((int.TryParse(saisie, out int nombre)))
                if ((nombre >= min && nombre <= max))
                    return nombre;
        }
    }

    public static string DemanderString() // Choix nombre non converti
    {
        while (true)
        {
            string saisie = Console.ReadLine() ?? string.Empty;

            bool estValid = (saisie != "1" || saisie != "2" || saisie != "3");
            if (estValid)
                return saisie;
        }
    }

    public static int NombreAleatoire(int min, int max) // Nombre aleatoire entre min et max
    {
        int nombreModuloAleatoire = Random.Shared.Next(min, max);
        return nombreModuloAleatoire;
    }

}
