using System.Runtime.Serialization;

namespace Service.Model
{
    [DataContract]
    public class ServiceReview
    {
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public int Rating { get; set; }

        [DataMember]
        public int ReviewId { get; set; }
        public override string ToString()
        {
            return $"{Rating + "/5 "} {Comment}";
        }
    }
}