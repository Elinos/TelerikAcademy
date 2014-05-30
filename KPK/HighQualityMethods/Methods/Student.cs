namespace Methods
{
    using System;
    using System.Text.RegularExpressions;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate = this.ParseDate(this.OtherInfo);
            DateTime secondDate = this.ParseDate(other.OtherInfo);

            return firstDate < secondDate;
        }

        private DateTime ParseDate(string text)
        {
            Match match = Regex.Match(text, @"\d+.\d+.\d+");

            if (match.Success)
            {
                string dateAsText = match.Groups[0].Value;
                DateTime date = DateTime.Parse(dateAsText);

                return date;
            }
            else
            {
                throw new ArgumentException("The text doesn't contains date");
            }
        }
    }
}
