namespace MyUmbracoProject
{
    public class CandidateModel
    {
        public string Name { get; set; }
        public List<string> Skills { get; set; }
        public int Experience { get; set; }
        public string InterviewFeedback { get; set; }
        public bool IsHired {  get; set; }
    }
}
