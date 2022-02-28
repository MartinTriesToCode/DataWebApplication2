namespace DataWebApplication.Models
{
    public class DoctorModel
    {

        public static string CheckTemp(double temp, string value)
        {
            string message1 = "You have a fever.";
            string message2 = "You have normal temperature.";
            string message3 = "You have hypothermia.";
            string message4 = "That's just absurd.";
            string message;

            if (value.Equals("Celsius"))
            {
                if (temp >= 38 && temp < 44.5)
                    message = message1;
                else if (temp < 35 && temp > 28)
                    message = message3;
                else if (temp <= 28 || temp >= 44.5)
                    message = message4;
                else
                    message = message2;
            }
            else
            {
                if (temp > 100.4 && temp < 112.1)
                    message = message1;
                else if (temp < 95 && temp > 82.4)
                    message = message3;
                else if (temp <= 82.4 || temp >= 112.1)
                    message = message4;
                else
                    message = message2;
            }
            return message;
        }
    }
}
