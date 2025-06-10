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

}
