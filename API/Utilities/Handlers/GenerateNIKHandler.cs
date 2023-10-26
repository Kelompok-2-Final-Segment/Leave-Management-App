namespace API.Utilities.Handlers
{
    public class GenerateNIKHandler
    {
        public static string GenerateNIK(String? lastNik = null)
        {
            if (lastNik == null)
            {
                return "111111";

            }

            var nik = Convert.ToInt32(lastNik) + 1;


            return nik.ToString("D6");

        }
    }
}
