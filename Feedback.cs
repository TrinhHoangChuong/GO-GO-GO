namespace Libs
{
    public class Feedback
    {
        public string FeedbackID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public Feedback(string feedbackID, int rating, string comment)
        {
            FeedbackID = feedbackID;
            Rating = rating;
            Comment = comment;
        }
    }
}