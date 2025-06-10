namespace GenerateurDeMotsDePasseConsole;

public class UtilitairesConsole
{

    public static int DemanderNombre() // Choix nombre utilisateur
    {
        while (true)
        {
            Console.Write("Veuillez saisir un nombre entre 4 et 40 de longueur de mot de passe : ");
            string saisie = Console.ReadLine() ?? string.Empty;

            if ((int.TryParse(saisie, out int nombre)))
                if ((nombre >= 4 && nombre <= 40))
                    return nombre;
        }
    }

    public static int NombreAleatoire()
    {
        int nombreModuloAleatoire = Random.Shared.Next(1, 4);
        return nombreModuloAleatoire;
    }

}
