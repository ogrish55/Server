﻿using System.Runtime.Serialization;


namespace Service.Model
{
    [DataContract]
    public class ServiceCustomer
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public int ZipCode { get; set; }
        [DataMember]
        public string PhoneNo { get; set; }
        [DataMember]
        public string Hash { get; set; }
        [DataMember]
        public string Salt { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string City { get; set; }
    }
}
