namespace Vigenere_Cipher
{
    public class Program
    {
        private static string plainText = "", key = "", encriptedText = "", decriptedText = "";
        private static char[] chKey;
        public static void Main(string[] args)
        {
            Console.Write("Enter plain text : ");
            plainText = Console.ReadLine().Replace(" ", "").ToLower();
            Console.Write("Enter your key : ");
            key = Console.ReadLine().Replace(" ", "").ToLower();

            if (key.Length <= plainText.Length)
            {
                //this for equalization key length to plain text length
                for (int i = 0; key.Length != plainText.Length; i++)
                {
                    if (i >= key.Length)
                        i = 0;
                    key += key[i].ToString();
                }

                //convert key string to array of char
                chKey = key.ToCharArray();


                Console.Write("Do you want encripted or decripted text (just enter 'e' or 'd' character) : ");
                char encriptOrDecript = char.Parse(Console.ReadLine());

                if (checkCorrectionPlainTextAndKey(plainText, key))
                {
                    encriptedText = goEncode(plainText, key);
                    decriptedText = goDecode(plainText, key);

                    //if encriptOrDecript variable equale to e , it's mean user want to encripted text
                    //if encriptOrDecript variable equale to d , it's mean user want to decripted text
                    if (encriptOrDecript == 'e')
                        Console.WriteLine($"Encripted text is : {encriptedText}");
                    else
                        Console.WriteLine($"Decripted text is : {decriptedText}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You should enter letters between A to Z.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your key lenght should be longer than plain text length.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static string goEncode(string plainText, string key)
        {
            char[] chPlainText = plainText.ToCharArray();
            for (int i = 0; i < chPlainText.Length; i++)
                encriptedText += (char)((((chPlainText[i] - 97) + (chKey[i] - 97)) % 26) + 97);
            return encriptedText;
        }

        public static string goDecode(string encodedText, string key)
        {
            char[] chEncodedText = encodedText.ToCharArray();
            for (int i = 0; i < chEncodedText.Length; i++)
            {
                if (((chEncodedText[i] - 97) - (chKey[i] - 97)) >= 0)
                    decriptedText += (char)(((chEncodedText[i] - 97) - (chKey[i] - 97)) % 26 + 97);
                else
                    decriptedText += (char)( 26 - (( ( (chEncodedText[i] - 97) - (chKey[i] - 97) ) * -1) % 26) + 97);
            }

            return decriptedText;
        }

        public static bool checkCorrectionPlainTextAndKey(string plainText, string key)
        {
            char[] chplainText = plainText.ToCharArray(), chKey = key.ToCharArray();
            for (int i = 0; i < chplainText.Length; i++)
                if (Convert.ToInt32(chplainText[i]) > 122 || Convert.ToInt32(chplainText[i]) < 97 || Convert.ToInt32(chKey[i]) > 122 || Convert.ToInt32(chKey[i]) < 97)
                    return false;

            return true;
        }

    }
}