namespace Caesar_Cipher
{
    internal class Program
    {
        public static string plainText = "";
        public static int placeCount = 0;
        public static string encriptedText = "", decriptedText = "";
        private static void Main(String[] args)
        {
            Console.Write("Enter your text : ");
            plainText = Console.ReadLine().Replace(" ", "").ToLower();
            Console.Write("Enter the place count : ");
            placeCount = int.Parse(Console.ReadLine());
            Console.Write("Do you want encripted or decripted text (just enter 'e' or 'd' character) : ");
            char encriptOrDecript = char.Parse(Console.ReadLine());
            if (checkCorrectionPlainTextAndPlaceCount(plainText, placeCount))
            {
                encriptedText = goEncription(plainText, placeCount);
                decriptedText = goDecription(encriptedText, placeCount);

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
                Console.WriteLine("You should enter letters between A to Z.\nYou should enter place count number between 1 to 24.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        //these methods will work for wpf version
        //public void getPlainText(string text)
        //{
        //    plainText = text.ToLower();
        //}
        //public void getPlaceCount(int num)
        //{
        //    placeCount = num;
        //}


        public static string goEncription(string plainText, int placeCount)
        {
            char[] ch = plainText.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                //this condition keeps values between A to Z .
                if (Convert.ToInt32(ch[i]) + placeCount <= 122)
                    ch[i] = ((char)(Convert.ToInt32(ch[i]) + placeCount));
                else
                    ch[i] = ((char)((Convert.ToInt32(ch[i]) + placeCount) - 26));
            }

            return new string(ch);
        }
        public static string goDecription(string encriptedText, int placeCout)
        {
            char[] ch = plainText.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                //this condition keeps values between A to Z .
                if (Convert.ToInt32(ch[i]) - placeCount >= 97)
                    ch[i] = ((char)(Convert.ToInt32(ch[i]) - placeCount));
                else
                    ch[i] = ((char)((Convert.ToInt32(ch[i]) - placeCount) + 26));
            }
            return new string(ch);
        }
        public static bool checkCorrectionPlainTextAndPlaceCount(string plainText, int placeCount)
        {
            char[] ch = plainText.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                if (Convert.ToInt32(ch[i]) > 122 || Convert.ToInt32(ch[i]) < 97)
                    return false;
            }

            if (placeCount < 0 || placeCount > 24)
                return false;

            return true;
        }
    }
}